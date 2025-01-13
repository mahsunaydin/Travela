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
    public class PageHeaderDetailManager : IPageHeaderDetailService
    {
        private readonly IPageHeaderDetailDal _pageHeaderDetailDal;

        public PageHeaderDetailManager(IPageHeaderDetailDal pageHeaderDetailDal)
        {
            _pageHeaderDetailDal = pageHeaderDetailDal;
        }

        public void TDelete(int id)
        {
            _pageHeaderDetailDal.Delete(id);
        }

        public PageHeaderDeatil TGetById(int id)
        {
            return _pageHeaderDetailDal.GetById(id);
        }

        public List<PageHeaderDeatil> TGetListAll()
        {
            return _pageHeaderDetailDal.GetListAll();
        }

        public void TInsert(PageHeaderDeatil entity)
        {
            _pageHeaderDetailDal.Insert(entity);
        }

        public void TUpdate(PageHeaderDeatil entity)
        {
            _pageHeaderDetailDal.Update(entity);
        }
    }
}
