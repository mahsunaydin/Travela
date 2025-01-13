using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Travela.WebUI.Dtos.About;

namespace Travela.WebUI.Controllers
{
    [Route("About")]
    public class AboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AboutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("AboutList")]
        public async Task<IActionResult> AboutList()
        {
            /*var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7294/api/About");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);*/

                ViewData["ActivePage"] = "AboutList";
                ViewData["BackgroundImage"] = "/travela-1.0.0/img/hakkimizda5.jpg";

                //return View(values);
            //}

            return View();
        }






    }
}
