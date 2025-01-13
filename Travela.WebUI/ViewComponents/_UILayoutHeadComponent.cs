using Microsoft.AspNetCore.Mvc;

namespace Travela.WebUI.ViewComponents
{
    public class _UILayoutHeadComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}
