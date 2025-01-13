using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Travela.EntityLayer.Concrete;
using Travela.WebUI.Dtos.Contact;

namespace Travela.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        /*public async Task<IActionResult> Index()
        {
            ViewData["ActivePage"] = "ContactList";
            ViewData["BackgroundImage"] = "/travela-1.0.0/img/contactPicture2.jpg";

            return View();
        }*/

        public IActionResult ContactList()
        {
            ViewData["ActivePage"] = "ContactList";
            ViewData["BackgroundImage"] = "/travela-1.0.0/img/contactPicture2.jpg";

            /*var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7294/api/Contact");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
                return View(values);
            }*/

            return View();          

        }

        /* [HttpGet]
         public IActionResult CreateContact()
         {
             return View();
         }

          [HttpPost]
          public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
          {
              var client = _httpClientFactory.CreateClient();
              var jsonData = JsonConvert.SerializeObject(createContactDto);

              StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

              var responseMessage = await client.PostAsync("https://localhost:7294/api/Contact", stringContent);

              if (responseMessage.IsSuccessStatusCode)
              {
                  return RedirectToAction("ContactList");
              }

              return View();
          }*/

        [HttpPost]
        public async Task<JsonResult> gonder(CreateContactDto createContactDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createContactDto);

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:7294/api/Contact", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return Json("Ok");
            }

            return Json("Hata");
        }









    }
}
