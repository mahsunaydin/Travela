using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travela.BusinessLayer.Abstract;
using Travela.DataAccessLayer.Abstract;
using Travela.EntityLayer.Concrete;

namespace Travela.BusinessLayer.Concrete
{
    public class CarouselManager : ICarouselService
    {
        private readonly ICarouselDal _carouselDal;

        public CarouselManager(ICarouselDal carouselDal)
        {
            _carouselDal = carouselDal;
        }

        public void TDelete(int id)
        {
            _carouselDal.Delete(id);
        }

        public UICarousel TGetById(int id)
        {
            return _carouselDal.GetById(id);
        }

        public List<UICarousel> TGetListAll()
        {
            return _carouselDal.GetListAll();
        }

        public void TInsert(UICarousel entity)
        {
            _carouselDal.Insert(entity);
        }

        public void TUpdate(UICarousel entity)
        {
            _carouselDal.Update(entity);
        }
    }
}
