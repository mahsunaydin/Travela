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
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void TDelete(int id)
        {
            _aboutDal.Delete(id);
        }

        public UIAbout TGetById(int id)
        {
            return _aboutDal.GetById(id);
        }

        public List<UIAbout> TGetListAll()
        {
            return _aboutDal.GetListAll();
        }

        public void TInsert(UIAbout entity)
        {
            _aboutDal.Insert(entity);
        }

        public void TUpdate(UIAbout entity)
        {
            _aboutDal.Update(entity);
        }
    }
}
