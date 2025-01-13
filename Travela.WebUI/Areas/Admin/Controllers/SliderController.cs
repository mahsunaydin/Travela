using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Travela.EntityLayer.Concrete;
using Travela.WebUI.Dtos.Carousel;

namespace Travela.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Slider")]
    [Authorize]
    public class SliderController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly UserManager<AppUser> _userManager;

        public SliderController(IHttpClientFactory httpClientFactory, UserManager<AppUser> userManager)
        {
            _httpClientFactory = httpClientFactory;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("SliderList")]
        public async Task<IActionResult> SliderList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7294/api/Carousel");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarouselDto>>(jsonData);

                var valueUser = await _userManager.FindByNameAsync(User.Identity.Name);
                ViewBag.userName = valueUser.Name + " " + valueUser.Surname;

                var responseMessage1 = await client.GetAsync("https://localhost:7294/api/Contact/MessageCount");
                var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
                ViewBag.messageCount = jsonData1;

                return View(values);
            }

            return View();
        }

        [HttpGet]
        [Route("UpdateSlider/{id}")]
        public async Task<IActionResult> UpdateSlider(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7294/api/Carousel/GetCarousel?id=" + id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateCarouselDto>(jsonData);

            var valueUser = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.userName = valueUser.Name + " " + valueUser.Surname;

            return View(values);
        }

        [HttpPost]
        [Route("UpdateSlider/{id}")]
        public async Task<IActionResult> UpdateSlider(UpdateCarouselDto updateCarouselDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateCarouselDto);

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            await client.PutAsync("https://localhost:7294/api/Carousel", stringContent);

            return RedirectToAction("SliderList");

        }

    }
}
