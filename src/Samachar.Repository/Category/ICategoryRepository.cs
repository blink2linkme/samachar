using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Samachar.Data.SqlServer;
using Samachar.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Samachar.Repository
{
    /// <summary>
    /// Represents a Repository for Category
    /// </summary>
    public interface ICategoryRepository
    {
        /// <summary>
        /// Get the Categories from Data source
        /// </summary>
        /// <returns>Collection of Category</returns>
        Task<ICollection<Category>> GetCategoriesAsync();

        /// <summary>
        /// Add or Update the Category
        /// </summary>
        /// <param name="category">Category object</param>
        /// <returns>Status of the process</returns>
        Task<int> AddOrUpdate(Category category);

        /// <summary>
        /// Returns a category
        /// </summary>
        /// <param name="id">Category Identifier</param>
        /// <returns>Category Object</returns>
        Task<Category> GetCategoryAsync(int id);
    }
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
            //if (category.Id == 0)
            //{
            //    category.CreatedBy = Convert.ToInt32(_httpContextAccessor.HttpContext.User.GetUserId());
            //    category.CreatedOn = DateTime.UtcNow;
            //    category.UpdatedBy = Convert.ToInt32(_httpContextAccessor.HttpContext.User.GetUserId());
            //    category.UpdatedOn = DateTime.UtcNow;
            //    _dbContext.Category.Add(category);
            //}
            //else
            //{
            //    category.UpdatedBy = Convert.ToInt32(_httpContextAccessor.HttpContext.User.GetUserId());
            //    category.UpdatedOn = DateTime.UtcNow;
            //    _dbContext.Category.Update(category);
            //}
            //_logger.LogInformation(category.ToString());
            //int result = await _dbContext.SaveChangesAsync();
            //_logger.LogInformation(result.ToString());
            //return result;
            return 1;
        }

        public async Task<ICollection<Category>> GetCategoriesAsync()
        {
            return null;// await _dbContext.Category.ToListAsync();
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
            return null; // await _dbContext.Category.FindAsync(id);
        }
    }
}
