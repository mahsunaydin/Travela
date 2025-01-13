using Microsoft.AspNetCore.Mvc;

namespace Travela.WebUI.Controllers
{
    public class StatisticController : Controller
    {
        private readonly IHttpClientFactory _htppClientFactory;

        public StatisticController(IHttpClientFactory htppClientFactory)
        {
            _htppClientFactory = htppClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _htppClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7294/api/Category/CategoryCount");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.c = jsonData;
            return View();
        }
    }
}
