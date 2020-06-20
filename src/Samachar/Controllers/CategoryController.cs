using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Samachar.Domain;
using Samachar.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Samachar.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService)
        {
            _categoryService = categoryService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var categories = _categoryService.GetCategoriesAsync();
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Category category)
        {
            try
            {
                if (await _categoryService.AddOrUpdate(category) > 0)
                    return RedirectToRoute("Index");
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        public async Task<IActionResult> Update(int id)
        {
            try
            {
                var category = await _categoryService.GetCategoryAsync(id);
                return View(category);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Category category)
        {
            try
            {
                if (await _categoryService.AddOrUpdate(category) > 0)
                    return RedirectToRoute("Index");
                return View(category);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }
    }
}
