using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Samachar.Core.Extensions;
using Samachar.Data.MSSQL;
using Samachar.Domain;
using Samachar.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Samachar.Repository
{
    public class TagRepository : ITagRepository
    {
        private readonly ILogger<TagRepository> _logger;
        private readonly SamacharDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TagRepository(SamacharDbContext dbContext, IHttpContextAccessor httpContextAccessor, ILogger<TagRepository> logger)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        public async Task<int> AddOrUpdate(Tag tag)
        {
            if (tag.Id == 0)
            {
                tag.CreatedBy = Convert.ToInt32(_httpContextAccessor.HttpContext.User.GetUserId());
                tag.CreatedOn = DateTime.UtcNow;
                tag.UpdatedBy = Convert.ToInt32(_httpContextAccessor.HttpContext.User.GetUserId());
                tag.UpdatedOn = DateTime.UtcNow;
                _dbContext.Tags.Add(tag);
            }
            else
            {
                tag.UpdatedBy = Convert.ToInt32(_httpContextAccessor.HttpContext.User.GetUserId());
                tag.UpdatedOn = DateTime.UtcNow;
                _dbContext.Tags.Update(tag);
                _dbContext.Entry(tag).State = EntityState.Modified;
                _dbContext.Entry(tag).Property(x => x.CreatedBy).IsModified = false;
                _dbContext.Entry(tag).Property(x => x.CreatedOn).IsModified = false;
            }
            _logger.LogInformation(tag.ToString());
            int result = await _dbContext.SaveChangesAsync();
            _logger.LogInformation(result.ToString());
            return result;
        }

        public async Task<TagsViewModel> GetTagsAsync(int page, int rows, string search)
        {
            var tagsQuery = _dbContext.Tags.Where(x => !x.IsDeleted && (string.IsNullOrEmpty(search) || x.Name.Contains(search)));
            var tags = tagsQuery.Skip((page - 1) * rows).Take(rows).ToList();
            var tagsCount = tagsQuery.Count();
            TagsViewModel tagsViewModel = new TagsViewModel { TotalRows = tagsCount, Tags = tags };
            return tagsViewModel;
        }

        public async Task<ICollection<Tag>> GetTagsAsync()
        {
            var tags = await _dbContext.Tags.Where(x => !x.IsDeleted).ToListAsync();
            return tags;
        }
        public async Task<Tag> GetTagAsync(int id)
        {
            return await _dbContext.Tags.FindAsync(id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var tag = await _dbContext.Tags.FindAsync(id);
            tag.IsDeleted = true;
            _dbContext.Tags.Update(tag);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
