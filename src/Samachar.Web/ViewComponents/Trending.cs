using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Samachar.Web.ViewComponents
{
    public class Trending : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
