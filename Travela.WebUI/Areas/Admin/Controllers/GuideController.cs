using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json;
using System.Text;
using Travela.EntityLayer.Concrete;
using Travela.WebUI.Dtos.Guide;

namespace Travela.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Guide")]
    [Authorize]

    public class GuideController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly UserManager<AppUser> _userManager;

        public GuideController(IHttpClientFactory httpClientFactory, UserManager<AppUser> userManager)
        {
            _httpClientFactory = httpClientFactory;
            _userManager = userManager;
        }

        [Route("GuidesList")]
        public async Task<IActionResult> GuidesList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7294/api/Guide");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultGuideDto>>(jsonData);

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
        [Route("CreateGuides")]
        public async Task<IActionResult> CreateGuides()
        {
            var valueUser = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.userName = valueUser.Name + " " + valueUser.Surname;

            return View();
        }


        [HttpPost]
        [Route("CreateGuides")]
        public async Task<IActionResult> CreateGuides(CreateGuideDto createGuideDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createGuideDto);

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7294/api/Guide", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("GuidesList");
            }

            return View();
        }


        [HttpGet]
        [Route("UpdateGuides/{id}")]
        public async Task<IActionResult> UpdateGuides(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7294/api/Guide/GetGuides?id=" + id);

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateGuideDto>(jsonData);

            var valueUser = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.userName = valueUser.Name + " " + valueUser.Surname;

            return View(values);
        }

        [HttpPost]
        [Route("UpdateGuides/{id}")]
        public async Task<IActionResult> UpdateGuides(UpdateGuideDto updateGuideDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateGuideDto);

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            await client.PutAsync("https://localhost:7294/api/Guide", stringContent);

            return RedirectToAction("GuidesList");
        }

        [Route("DeleteGuides/{id}")]
        public async Task<IActionResult> DeleteGuides(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync("https://localhost:7294/api/Guide?id=" + id);

            return RedirectToAction("GuidesList");
        }



    }
}
