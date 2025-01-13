using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Travela.EntityLayer.Concrete;
using Travela.WebUI.Dtos.RegisterDto;

namespace Travela.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Register")]

    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [Route("Index")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Index")]
        [HttpPost]
        public async Task<IActionResult> Index(CreateNewUserDto createNewUserDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var appUser = new AppUser()
            {
                Name = createNewUserDto.Name,
                Email = createNewUserDto.Mail,
                Surname = createNewUserDto.Surname,
                UserName = createNewUserDto.Username
            };

            var result = await _userManager.CreateAsync(appUser, createNewUserDto.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }

            return View();
        }



    }
}
