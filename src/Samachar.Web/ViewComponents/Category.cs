using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Samachar.Service;
using System.Threading.Tasks;

namespace Samachar.Web.ViewComponents
{
    public class Category : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<Category> _logger;
        public Category(ICategoryService categoryService, ILogger<Category> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _categoryService.GetSequenceCategoriesAsync();
            return View(categories);
        }
    }
}
