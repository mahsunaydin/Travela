using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Travela.BusinessLayer.Abstract;
using Travela.EntityLayer.Concrete;

namespace Travela1.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        public IActionResult ServiceList()
        {
            var values = _serviceService.TGetListAll();
            return Ok(values);
        }


        [HttpGet("ServiceCount")]
        public IActionResult ServiceCount()
        {
            return Ok(_serviceService.TGetServiceCount());
        }

        [HttpGet("GetService")]
        public IActionResult GetService(int id)
        {
            var value = _serviceService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateServices(UIService service)
        {
            _serviceService.TUpdate(service);
            return Ok("Güncelleme Başarıyla Yapıldı");
        }

        [HttpPost]
        public IActionResult CreateService(UIService service)
        {
            _serviceService.TInsert(service);
            return Ok("Ekleme Başarıyla Yapıldı.");
        }

        [HttpDelete]
        public IActionResult DeleteService(int id)
        {
            _serviceService.TDelete(id);
            return Ok("Silme Başarıyla Yapıldı.");
        }




    }
}
