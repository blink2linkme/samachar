using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Samachar.Core.Constants;
using Samachar.Core.Helper;
using Samachar.Domain;
using Samachar.Domain.ViewModels;
using Samachar.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Samachar.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IFileHelper _fileHelper;
        private readonly ILogger<CategoryService> _logger;

        public CategoryService(IHostingEnvironment hostingEnvironment, ICategoryRepository categoryRepository, IFileHelper fileHelper, ILogger<CategoryService> logger)
        {
            _hostingEnvironment = hostingEnvironment;
            _categoryRepository = categoryRepository;
            _fileHelper = fileHelper;
            _logger = logger;
        }

        public async Task<CategoryViewModel> GetCategoriesAsync(int page, int rows, string search)
        {
            return await _categoryRepository.GetCategoriesAsync(page, rows, search);
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _categoryRepository.GetCategoriesAsync();
        }

        public async Task<int> AddOrUpdate(Category category)
        {
            //file helper
            if (category.Picture != null && category.Picture.Length > 0)
            {
                string fileName = category.Picture.FileName;
                string relativePath = Path.Combine(LocationConstants.CategoryImages, $"{category.Name}_{DateTime.Now.Ticks}_{fileName}");
                string fullPath = Path.Combine(_hostingEnvironment.WebRootPath, relativePath);
                await _fileHelper.CopyFormFileAsync(category.Picture, fullPath);
                string filePath = relativePath;
                category.ImageUrl = filePath;
            }
            return await _categoryRepository.AddOrUpdate(category);
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
            return await _categoryRepository.GetCategoryAsync(id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _categoryRepository.DeleteAsync(id);
        }

        public async Task<ICollection<Category>> GetSequenceCategoriesAsync()
        {
            return await _categoryRepository.GetSequenceCategoriesAsync();
        }
    }
}
