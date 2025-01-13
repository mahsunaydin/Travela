using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Travela.EntityLayer.Concrete;

namespace Travela.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/Admin/Dashboard")]
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(IHttpClientFactory httpClientFactory, UserManager<AppUser> userManager)
        {
            _httpClientFactory = httpClientFactory;
            _userManager = userManager;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage1 = await client.GetAsync("https://localhost:7294/api/Category/CategoryCount");
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            ViewBag.categoryCount = jsonData1; //turlar category

            var responseMessage2 = await client.GetAsync("https://localhost:7294/api/Service/ServiceCount");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.serviceCount = jsonData2; //hizmetler service

            var responseMessage3 = await client.GetAsync("https://localhost:7294/api/Contact/MessageCount");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.messageCount = jsonData3; //mesajlar contact

            var responseMessage4 = await client.GetAsync("https://localhost:7294/api/Destination/RouteCount");
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.routeCount = jsonData4; //rotalar destination

            var chartData = new List<object>
            {
                 new { categoryName = "Turlar", adet = 6 },
                 new { categoryName = "Rotalar", adet = 4 },
                 new { categoryName = "Hizmetler", adet = 8 },
                 new { categoryName = "Mesajlar", adet = 9 },
            };

            // Veriyi JSON formatına dönüştür
            var chartDataJson = JsonConvert.SerializeObject(chartData);
            ViewBag.ChartDataJson = chartDataJson;

            var valueUser = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.userName = valueUser.Name + " " + valueUser.Surname;


            return View();
        }
    }
}
