using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Samachar.Domain;
using Samachar.Service;
using System;
using System.Threading.Tasks;

namespace Samachar.Controllers
{
    public class CategoryController : AdminController
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService)
        {
            _categoryService = categoryService;
            _logger = logger;
        }

        public async Task<IActionResult> Index(int page = 1, int rows = 10, string search = null)
        {
            try
            {
                var categories = await _categoryService.GetCategoriesAsync(page, rows, search);
                categories.Rows = rows;
                categories.Page = page;
                return View(categories);
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
                if (ModelState.IsValid)
                {
                    if (await _categoryService.AddOrUpdate(category) > 0)
                        return RedirectToAction("Index");
                }
                return View(category);
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
                if (ModelState.IsValid)
                {
                    if (await _categoryService.AddOrUpdate(category) > 0)
                        return RedirectToAction("Index");

                }
                return View(category);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (await _categoryService.DeleteAsync(id))
                    return Ok();
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }
    }
}
