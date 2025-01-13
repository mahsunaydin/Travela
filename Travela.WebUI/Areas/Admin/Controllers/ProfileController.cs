using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Travela.EntityLayer.Concrete;
using Travela.WebUI.Dtos.Profile;
using Travela.WebUI.Models.ViewModels;

namespace Travela.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Profile")]
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpClientFactory _httpClientFactory;

        public ProfileController(UserManager<AppUser> userManager, IHttpClientFactory httpClientFactory)
        {
            _userManager = userManager;
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userInfo = await _userManager.FindByNameAsync(User.Identity.Name);

            var model = new LoginUserInfoModel
            {
                Username = userInfo.UserName,
                Name = userInfo.Name,
                Surname = userInfo.Surname,
                Mail = userInfo.Email,
                PhoneNumber = userInfo.PhoneNumber
            };

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7294/api/Contact/MessageCount");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.messageCount = jsonData;

            ViewBag.userName = userInfo.Name + " " + userInfo.Surname; //layout için tanımlandı

            return View(model);
        }

        [Route("Index")]
        [HttpPost]
        public IActionResult Index(ResultUserProfileInfoDto resultUserProfileInfoDto)
        {
            return View();
        }



    }
}
