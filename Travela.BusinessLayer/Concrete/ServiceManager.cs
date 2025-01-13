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
    public class ServiceManager : IServiceService
    {
        private readonly IServiceDal _serviceDal;

        public ServiceManager(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }

        public void TDelete(int id)
        {
            _serviceDal.Delete(id);
        }

        public UIService TGetById(int id)
        {
            return _serviceDal.GetById(id);
        }

        public List<UIService> TGetListAll()
        {
            return _serviceDal.GetListAll();
        }

        public void TInsert(UIService entity)
        {
            _serviceDal.Insert(entity);
        }

        public void TUpdate(UIService entity)
        {
            _serviceDal.Update(entity);
        }

        public int TGetServiceCount()
        {
            return _serviceDal.GetServiceCount();
        }

    }
}
