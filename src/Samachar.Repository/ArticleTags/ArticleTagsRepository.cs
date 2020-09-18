using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Samachar.Core.Extensions;
using Samachar.Data.MSSQL;
using Samachar.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Samachar.Repository
{
    public class ArticleTagsRepository : IArticleTagsRepository
    {
        private readonly ILogger<ArticleRepository> _logger;
        private readonly SamacharDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ArticleTagsRepository(SamacharDbContext dbContext, IHttpContextAccessor httpContextAccessor, ILogger<ArticleRepository> logger)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        public async Task<int> AddOrUpdate(ICollection<ArticleTags> articleTags)
        {
            _dbContext.ArticleTags.RemoveRange(_dbContext.ArticleTags.Where(x => x.ArticleId == articleTags.First().ArticleId));
            articleTags.ToList().ForEach(x =>
            {
                x.CreatedBy = Convert.ToInt32(_httpContextAccessor.HttpContext.User.GetUserId());
                x.CreatedOn = DateTime.UtcNow;
                x.UpdatedBy = Convert.ToInt32(_httpContextAccessor.HttpContext.User.GetUserId());
                x.UpdatedOn = DateTime.UtcNow;
            });
            await _dbContext.ArticleTags.AddRangeAsync(articleTags);
            await _dbContext.SaveChangesAsync();
            return 1;
            //if (articleTags.Id == 0)
            //{
            //    articleTags.CreatedBy = Convert.ToInt32(_httpContextAccessor.HttpContext.User.GetUserId());
            //    articleTags.CreatedOn = DateTime.UtcNow;
            //    articleTags.UpdatedBy = Convert.ToInt32(_httpContextAccessor.HttpContext.User.GetUserId());
            //    articleTags.UpdatedOn = DateTime.UtcNow;
            //    await _dbContext.ArticleTags.AddAsync(articleTags);
            //}
            //else
            //{
            //    articleTags.UpdatedBy = Convert.ToInt32(_httpContextAccessor.HttpContext.User.GetUserId());
            //    articleTags.UpdatedOn = DateTime.UtcNow;
            //    _dbContext.ArticleTags.Update(articleTags);
            //    _dbContext.Entry(articleTags).State = EntityState.Modified;
            //    _dbContext.Entry(articleTags).Property(x => x.CreatedBy).IsModified = false;
            //    _dbContext.Entry(articleTags).Property(x => x.CreatedOn).IsModified = false;
            //}
            //_logger.LogInformation(articleTags.ToString());
            //int result = await _dbContext.SaveChangesAsync();
            //_logger.LogInformation(result.ToString());
            //return result;
        }

        public async Task<ICollection<ArticleTags>> GetArticlesAsync(int page, int rows)
        {
            return await _dbContext.ArticleTags.Where(x => !x.IsDeleted).Take(rows).Skip(page > 1 ? page * rows : 0).ToListAsync();
        }

        public async Task<ICollection<ArticleTags>> GetArticlesTagsAsync(int articleId)
        {
            return await _dbContext.ArticleTags.Where(x => !x.IsDeleted && x.ArticleId == articleId).ToListAsync();
        }

        public async Task<ArticleTags> GetArticleAsync(int id)
        {
            return await _dbContext.ArticleTags.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
