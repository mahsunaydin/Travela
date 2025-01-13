using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travela.DataAccessLayer.Abstract;
using Travela.DataAccessLayer.Context;
using Travela.DataAccessLayer.Repositories;
using Travela.EntityLayer.Concrete;

namespace Travela.DataAccessLayer.EntityFramework
{
    public class EfServiceDal : GenericRepository<UIService>, IServiceDal
    {
        public EfServiceDal(TravelaContext context) : base(context)
        {

        }

        public int GetServiceCount()
        {
            var context = new TravelaContext();
            var value = context.UIServices.Count();
            return value;
        }



    }
}
