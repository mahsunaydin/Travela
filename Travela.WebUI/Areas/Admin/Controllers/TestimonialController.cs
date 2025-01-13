using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Travela.EntityLayer.Concrete;
using Travela.WebUI.Dtos.Testimonial;

namespace Travela.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Testimonial")]
    [Authorize]
    public class TestimonialController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly UserManager<AppUser> _userManager;

        public TestimonialController(IHttpClientFactory httpClientFactory, UserManager<AppUser> userManager)
        {
            _httpClientFactory = httpClientFactory;
            _userManager = userManager;
        }

        [HttpGet("TestimonialsList")]
        public async Task<IActionResult> TestimonialsList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7294/api/Testimonial");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);

                var valueUser = await _userManager.FindByNameAsync(User.Identity.Name);
                ViewBag.userName = valueUser.Name + " " + valueUser.Surname;

                var responseMessage1= await client.GetAsync("https://localhost:7294/api/Contact/MessageCount");
                var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
                ViewBag.messageCount = jsonData1;

                return View(values);
            }

            return View();
        }

    }
}
