using Microsoft.AspNetCore.Mvc;

namespace Travela.WebUI.ViewComponents
{
    public class _UILayoutFooterComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
