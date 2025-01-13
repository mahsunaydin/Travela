using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Travela.WebUI.Dtos.Guide;

namespace Travela.WebUI.Controllers
{
    public class GuideController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public GuideController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> GuideList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7294/api/Guide");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultGuideDto>>(jsonData);

                return View(values);

            }

            return View();
        }
    }
}
