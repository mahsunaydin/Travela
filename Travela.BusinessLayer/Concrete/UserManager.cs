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
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void TDelete(int id)
        {
            _userDal.Delete(id);
        }

        public User TGetById(int id)
        {
            return _userDal.GetById(id);
        }

        public List<User> TGetListAll()
        {
            return _userDal.GetListAll();
        }

        public void TInsert(User entity)
        {
            _userDal.Insert(entity);
        }

        public void TUpdate(User entity)
        {
            _userDal.Update(entity);
        }
    }
}
