using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Samachar.Core.Extensions;
using Samachar.Data.MSSQL;
using Samachar.Domain;
using Samachar.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Samachar.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ILogger<CategoryRepository> _logger;
        private readonly SamacharDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CategoryRepository(SamacharDbContext dbContext, IHttpContextAccessor httpContextAccessor, ILogger<CategoryRepository> logger)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        public async Task<int> AddOrUpdate(Category category)
        {
            if (category.Id == 0)
            {
                category.CreatedBy = Convert.ToInt32(_httpContextAccessor.HttpContext.User.GetUserId());
                category.CreatedOn = DateTime.UtcNow;
                category.UpdatedBy = Convert.ToInt32(_httpContextAccessor.HttpContext.User.GetUserId());
                category.UpdatedOn = DateTime.UtcNow;
                _dbContext.Category.Add(category);
            }
            else
            {
                category.UpdatedBy = Convert.ToInt32(_httpContextAccessor.HttpContext.User.GetUserId());
                category.UpdatedOn = DateTime.UtcNow;
                _dbContext.Category.Update(category);
                _dbContext.Entry(category).State = EntityState.Modified;
                _dbContext.Entry(category).Property(x => x.CreatedBy).IsModified = false;
                _dbContext.Entry(category).Property(x => x.CreatedOn).IsModified = false;
                if (string.IsNullOrEmpty(category.ImageUrl))
                    _dbContext.Entry(category).Property(x => x.ImageUrl).IsModified = false;
            }
            _logger.LogInformation(category.ToString());
            int result = await _dbContext.SaveChangesAsync();
            _logger.LogInformation(result.ToString());
            return result;
        }

        public async Task<CategoryViewModel> GetCategoriesAsync(int page, int rows, string search)
        {
            var categoryQuery = _dbContext.Category.Where(x => !x.IsDeleted && (string.IsNullOrEmpty(search) || x.Name.Contains(search)));
            var categories = categoryQuery.Skip((page - 1) * rows).Take(rows).ToList();
            var categoriesCount = categoryQuery.Count();
            CategoryViewModel categoryViewModel = new CategoryViewModel { TotalRows = categoriesCount, Categories = categories };
            return categoryViewModel;
        }

        public async Task<ICollection<Category>> GetCategoriesAsync()
        {
            return await _dbContext.Category.Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
            return await _dbContext.Category.FindAsync(id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _dbContext.Category.FindAsync(id);
            category.IsDeleted = true;
            _dbContext.Category.Update(category);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ICollection<Category>> GetSequenceCategoriesAsync()
        {
            return await _dbContext.Category.Where(x => !x.IsDeleted).OrderBy(x=>x.Sequence).AsNoTracking().ToListAsync();
        }
    }
}
