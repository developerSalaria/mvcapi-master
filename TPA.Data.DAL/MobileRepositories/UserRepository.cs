using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA.Common.Core.MobileModel;

namespace TPA.Data.DAL.MobileRepositories
{
    public class UserRepository : BaseRepository,IDisposable
    {
        public UserModel GetUser(UserModel user)
        {
            return QueryExecutor.Query<UserModel>(MobileStoreProcedures.USP_Mobile_GetUserByEmail.ToString(), new { user.Email }, CommandType.StoredProcedure).ToList().FirstOrDefault();
        }

        public Result Register(UserModel user)
        {
            return QueryExecutor.QueryFirst<Result>(MobileStoreProcedures.USP_Mobile_Register.ToString(), new { user.Email,user.Password,user.UserIdentity,user.Name,user.DOB }, CommandType.StoredProcedure);
        }
        public void Dispose()
        {
           
        }
    }
}
