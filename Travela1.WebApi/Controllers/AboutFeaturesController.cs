using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Travela.BusinessLayer.Abstract;
using Travela.EntityLayer.Concrete;

namespace Travela1.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutFeaturesController : ControllerBase
    {
        private readonly IAboutFeaturesService _aboutFeaturesService;

        public AboutFeaturesController(IAboutFeaturesService aboutFeaturesService)
        {
            _aboutFeaturesService = aboutFeaturesService;
        }

        [HttpGet]
        public IActionResult AboutFeaturesList()
        {
            var values = _aboutFeaturesService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateAboutFeatures(UIAboutFeature aboutFeature)
        {
            _aboutFeaturesService.TInsert(aboutFeature);
            return Ok("Ekleme işlemi başarıyla tamamlandı.");
        }

        [HttpPut]
        public IActionResult UpdateAboutFeatures(UIAboutFeature aboutFeature)
        {
            _aboutFeaturesService.TUpdate(aboutFeature);
            return Ok("Günceleme işlemi başarıyla tamamlandı.");
        }

        [HttpDelete]
        public IActionResult DeleteAboutFeatures(int id)
        {
            _aboutFeaturesService.TDelete(id);
            return Ok("Silme işlemi başarıyla tamamlandı");
        }


    }
}
