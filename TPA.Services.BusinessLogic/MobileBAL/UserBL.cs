using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA.Common.Core.MobileModel;
using TPA.Data.DAL.MobileRepositories;

namespace TPA.Services.BusinessLogic.MobileBAL
{
    public class UserBL : IDisposable
    {
        private UserRepository _repo;
        public UserBL()
        {
            _repo = new UserRepository();
        }

        public UserModel GetUser(UserModel user)
        {
            return _repo.GetUser(user);
        }

        public Result Register(UserModel user)
        {
            return _repo.Register(user);
        }

        public void Dispose()
        {
            _repo.Dispose();
        }
    }
}
