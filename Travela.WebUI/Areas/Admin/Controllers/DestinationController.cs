using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Travela.EntityLayer.Concrete;
using Travela.WebUI.Dtos;

namespace Travela.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Destination")]
    [Authorize]
    public class DestinationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly UserManager<AppUser> _userManager;

        public DestinationController(IHttpClientFactory httpClientFactory, UserManager<AppUser> userManager)
        {
            _httpClientFactory = httpClientFactory;
            _userManager = userManager;
        }

        [Route("DestinationsList")]
        public async Task<IActionResult> DestinationsList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7294/api/Destination");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultDestinationDto>>(jsonData);

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
        [Route("UpdateDestinations/{id}")]
        public async Task<IActionResult> UpdateDestinations(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7294/api/Destination/GetDestination?id=" + id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateDestinationDto>(jsonData);

            var valueUser = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.userName = valueUser.Name + " " + valueUser.Surname;

            return View(values);
        }

        [HttpPost]
        [Route("UpdateDestinations/{id}")]
        public async Task<IActionResult> UpdateDestinations(UpdateDestinationDto updateDestinationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateDestinationDto);

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            await client.PutAsync("https://localhost:7294/api/Destination", stringContent);

            return RedirectToAction("DestinationsList");
        }

        [HttpGet]
        [Route("CreateDestinations")]
        public async Task<IActionResult> CreateDestinations()
        {
            var valueUser = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.userName = valueUser.Name + " " + valueUser.Surname;

            return View();
        }

        [HttpPost]
        [Route("CreateDestinations")]
        public async Task<IActionResult> CreateDestinations(CreateDestinationDto createDestinationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createDestinationDto);

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7294/api/Destination", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("DestinationsList");
            }

            return View();
        }


        [Route("DeleteDestinations/{id}")]
        public async Task<IActionResult> DeleteDestinations(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync("https://localhost:7294/api/Destination?id=" + id);

            return RedirectToAction("DestinationsList");
        }







    }
}
