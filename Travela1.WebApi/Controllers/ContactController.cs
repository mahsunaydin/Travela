using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Travela.BusinessLayer.Abstract;
using Travela.EntityLayer.Concrete;

namespace Travela1.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _contactService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateContact(Contact contact)
        {
            _contactService.TInsert(contact);
            return Ok("Mesaj başarıyla eklendi.");
        }

        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            _contactService.TDelete(id);
            return Ok("Mesaj başarıyla silindi.");
        }

        [HttpGet("MessageCount")]
        public IActionResult MessageCount()
        {
            return Ok(_contactService.TGetMessageCount());
        }


        [HttpGet("GetContacts")]
        public IActionResult GetContacts(int id)
        {
            var value = _contactService.TGetById(id);
            return Ok(value);
        }



    }
}
