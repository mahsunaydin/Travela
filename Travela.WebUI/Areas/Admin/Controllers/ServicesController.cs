using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Travela.WebUI.Dtos.Services;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Travela.EntityLayer.Concrete;

namespace Travela.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Services")]
    [Authorize]
    public class ServicesController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly UserManager<AppUser> _userManager;

        public ServicesController(IHttpClientFactory httpClientFactory, UserManager<AppUser> userManager)
        {
            _httpClientFactory = httpClientFactory;
            _userManager = userManager;
        }

        [Route("ServicesList")]
        public async Task<IActionResult> ServicesList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7294/api/Service");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);

                var valueUser = await _userManager.FindByNameAsync(User.Identity.Name);
                ViewBag.userName = valueUser.Name + " " + valueUser.Surname;

                var responseMessage1 = await client.GetAsync("https://localhost:7294/api/Contact/MessageCount");
                var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
                ViewBag.messageCount = jsonData1;

                return View(value);
            }

            return View();
        }


        [HttpGet]
        [Route("UpdateServices/{id}")]
        public async Task<IActionResult> UpdateServices(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7294/api/Service/GetService?id=" + id);

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateServiceDto>(jsonData);

            var valueUser = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.userName = valueUser.Name + " " + valueUser.Surname;

            return View(values);
        }

        [HttpPost]
        [Route("UpdateServices/{id}")]
        public async Task<IActionResult> UpdateServices(UpdateServiceDto updateServiceDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateServiceDto);

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            await client.PutAsync("https://localhost:7294/api/Service", stringContent);

            return RedirectToAction("ServicesList");
        }

        [HttpGet]
        [Route("CreateServices")]
        public async Task<IActionResult> CreateServices()
        {
            var valueUser = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.userName = valueUser.Name + " " + valueUser.Surname;

            return View();
        }


        [HttpPost]
        [Route("CreateServices")]
        public async Task<IActionResult> CreateServices(CreateServiceDto createServiceDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createServiceDto);

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7294/api/Service", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ServicesList");
            }

            return View();
        }


        [Route("DeleteServices/{id}")]
        public async Task<IActionResult> DeleteServices(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync("https://localhost:7294/api/Service?id=" + id);

            return RedirectToAction("ServicesList");
            
        }







    }
}
