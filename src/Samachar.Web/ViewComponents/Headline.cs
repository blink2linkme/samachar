using Microsoft.AspNetCore.Mvc;
using Samachar.Domain.ViewModels;
using Samachar.Service;
using System.Threading.Tasks;

namespace Samachar.Web.ViewComponents
{
    public class Headline : ViewComponent
    {
        private readonly IArticleService _articleService;
        public Headline(IArticleService articleService)
        {
            _articleService = articleService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            HeadlineViewModel headlineViewModel = new HeadlineViewModel();
            headlineViewModel.Latest = await _articleService.GetLatestAsync();
            headlineViewModel.Popular = await _articleService.GetPopularArticleAsync();
            return View(headlineViewModel);
        }
    }
}
