using Microsoft.Extensions.Logging;
using Samachar.Domain;
using Samachar.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Samachar.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<CategoryService> _logger;

        public CategoryService(ICategoryRepository categoryRepository, ILogger<CategoryService> logger)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
        }

        public async Task<ICollection<Category>> GetCategoriesAsync()
        {
            return await _categoryRepository.GetCategoriesAsync();
        }

        public async Task<int> AddOrUpdate(Category category)
        {
            return await _categoryRepository.AddOrUpdate(category);
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
            return await _categoryRepository.GetCategoryAsync(id);
        }
    }
}
