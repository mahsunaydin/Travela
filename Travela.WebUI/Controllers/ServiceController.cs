using Microsoft.AspNetCore.Mvc;

namespace Travela.WebUI.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ServiceController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult ServiceList()
        {
            ViewData["ActivePage"] = "ServiceList";
            ViewData["BackgroundImage"] = "/travela-1.0.0/img/servicesPicture1.jpg";

            return View();
        }
    }
}
