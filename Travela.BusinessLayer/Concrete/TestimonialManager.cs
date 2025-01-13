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
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestimonialDal _testimonialDal;

        public TestimonialManager(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }

        public void TDelete(int id)
        {
            _testimonialDal.Delete(id);
        }

        public UITestimonial TGetById(int id)
        {
            return _testimonialDal.GetById(id);
        }

        public List<UITestimonial> TGetListAll()
        {
            return _testimonialDal.GetListAll();
        }

        public void TInsert(UITestimonial entity)
        {
            _testimonialDal.Insert(entity);
        }

        public void TUpdate(UITestimonial entity)
        {
            _testimonialDal.Update(entity);
        }
    }
}
