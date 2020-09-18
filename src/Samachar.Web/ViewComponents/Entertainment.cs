using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Samachar.Web.ViewComponents
{
    public class Entertainment : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
