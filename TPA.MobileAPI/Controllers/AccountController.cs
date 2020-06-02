using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TPA.Common.Core.MobileModel;
using TPA.MobileAPI.Common;
using TPA.Services.BusinessLogic.MobileBAL;

namespace TPA.MobileAPI.Controllers
{
    public class AccountController : ApiController
    {
        UserBL _bal;
        AccountController()
        {
            _bal = new UserBL();
        }

        [HttpPost]
        [Route("api/Account/Register")]
        public Result Register(UserModel user)
        {
            user.Password = Utility.Encrypt(user.Password);
           return _bal.Register(user);
        }
    }
}
