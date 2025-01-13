using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Travela.BusinessLayer.Abstract;
using Travela.EntityLayer.Concrete;

namespace Travela1.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarouselController : ControllerBase
    {
        private readonly ICarouselService _carouselService;

        public CarouselController(ICarouselService carouselService)
        {
            _carouselService = carouselService;
        }

        [HttpGet]
        public IActionResult CarouselList()
        {
            var values = _carouselService.TGetListAll();
            return Ok(values);
        }

        [HttpGet("GetCarousel")]
        public IActionResult GetCarousel(int id)
        {
            var value = _carouselService.TGetById(id);
            return Ok(value);
        }


        [HttpPut]
        public IActionResult UpdateCarousel(UICarousel carousel)
        {
            _carouselService.TUpdate(carousel);
            return Ok("Carousel güncellemesi yapıldı");
        }







    }
}
