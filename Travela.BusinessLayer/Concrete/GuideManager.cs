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
    public class GuideManager : IGuideService
    {
        private readonly IGuideDal _guideDal;

        public GuideManager(IGuideDal guideDal)
        {
            _guideDal = guideDal;
        }

        public void TDelete(int id)
        {
            _guideDal.Delete(id);
        }

        public UIGuide TGetById(int id)
        {
            return _guideDal.GetById(id);
        }

        public List<UIGuide> TGetListAll()
        {
            return _guideDal.GetListAll();
        }

        public void TInsert(UIGuide entity)
        {
            _guideDal.Insert(entity);
        }

        public void TUpdate(UIGuide entity)
        {
            _guideDal.Update(entity);
        }
    }
}
