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
    public class AboutFeaturesManager : IAboutFeaturesService
    {
        private readonly IAboutFeaturesDal _aboutFeaturesDal;

        public AboutFeaturesManager(IAboutFeaturesDal aboutFeaturesDal)
        {
            _aboutFeaturesDal = aboutFeaturesDal;
        }

        public void TDelete(int id)
        {
            _aboutFeaturesDal.Delete(id);
        }

        public UIAboutFeature TGetById(int id)
        {
            return _aboutFeaturesDal.GetById(id);
        }

        public List<UIAboutFeature> TGetListAll()
        {
            return _aboutFeaturesDal.GetListAll();
        }

        public void TInsert(UIAboutFeature entity)
        {
            _aboutFeaturesDal.Insert(entity);
        }

        public void TUpdate(UIAboutFeature entity)
        {
            _aboutFeaturesDal.Update(entity);
        }
    }
}
