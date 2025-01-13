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
    [Route("Admin/Categories")]
    [Authorize]
    public class CategoriesController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly UserManager<AppUser> _userManager;

        public CategoriesController(IHttpClientFactory httpClientFactory, UserManager<AppUser> userManager)
        {
            _httpClientFactory = httpClientFactory;
            _userManager = userManager;
        }

        [Route("CategoriesList")]
        public async Task<IActionResult> CategoriesList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7294/api/Category");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

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
        [Route("UpdateCategories/{id}")]
        public async Task<IActionResult> UpdateCategories(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7294/api/Category/GetCategory?id=" + id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);

            var valueUser = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.userName = valueUser.Name + " " + valueUser.Surname;

            return View(values);
        }

        [HttpPost]
        [Route("UpdateCategories/{id}")]
        public async Task<IActionResult> UpdateCategories(UpdateCategoryDto updateCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateCategoryDto);

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            await client.PutAsync("https://localhost:7294/api/Category", stringContent);

            return RedirectToAction("CategoriesList");
        }

        [HttpGet]
        [Route("CreateCategories")]
        public async Task<IActionResult> CreateCategories()
        {
            var valueUser = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.userName = valueUser.Name + " " + valueUser.Surname;

            return View();
        }

        [HttpPost]
        [Route("CreateCategories")]
        public async Task<IActionResult> CreateCategories(CreateCategoryDto createCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCategoryDto);

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7294/api/Category", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CategoriesList");
            }

            return View();
        }


        [Route("DeleteCategories/{id}")]
        public async Task<IActionResult> DeleteCategories(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync("https://localhost:7294/api/Category?id=" + id);

            return RedirectToAction("CategoriesList");
        }



    }
}
