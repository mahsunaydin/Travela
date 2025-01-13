using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Travela.BusinessLayer.Abstract;
using Travela.EntityLayer.Concrete;

namespace Travela1.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuideController : ControllerBase
    {
        private readonly IGuideService _guideService;

        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }

        [HttpGet]
        public IActionResult GuideList()
        {
            var values = _guideService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateGuides(UIGuide guide)
        {
            _guideService.TInsert(guide);
            return Ok("Rehber Ekleme İşlemi Tamamlandı");
        }

        [HttpGet("GetGuides")]
        public IActionResult GetGuides(int id)
        {
            var value = _guideService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateGuides(UIGuide guide)
        {
            _guideService.TUpdate(guide);
            return Ok("Rehber Güncellemesi Yapıldı");
        }

        [HttpDelete]
        public IActionResult DeleteGuides(int id)
        {
            _guideService.TDelete(id);
            return Ok("Rehber Silmesi Yapıldı.");
        }


    }
}
