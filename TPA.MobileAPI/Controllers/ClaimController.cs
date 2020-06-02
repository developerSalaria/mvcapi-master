
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web.Http;
using TPA.Common.Core.MobileModel;
using TPA.Services.BusinessLogic.MobileBAL;
using System.Web;
using TPA.Common.Core.Model;

namespace TPA.MobileAPI.Controllers
{
    [Authorize]
    public class ClaimController : ApiController
    {
        ClaimBL _bal;
        ClaimController()
        {
            _bal = new ClaimBL();
        }


        [Route("api/Countries")]
        public IEnumerable<CountryModel> GetCoutries(string EmployeeCode)
        {
            return _bal.GetCountries(EmployeeCode);
        }

        [Route("api/ServiceType")]
        public IEnumerable<ServiceTypeModel> GetServiceType(string EmployeeCode)
        {
            return _bal.GetServiceType(EmployeeCode);
        }

        [Route("api/Providers")]
        public IEnumerable<ProviderModel> GetProviders(string EmployeeCode)
        {
            return _bal.GetProviders(EmployeeCode);
        }


        [Route("api/Currency")]
        public IEnumerable<CurrencyModel> GetCurrency(string EmployeeCode)
        {
            return _bal.GetCurrency(EmployeeCode);
        }

        [HttpPost]
        [Route("api/SaveClaim")]
        public Result SaveClaim(ClaimModel claim)
        {
            return _bal.SaveClaim(claim);
        }


        [HttpPost]
        [Route("api/SavePaymentMethod")]
        public Result SavePaymentMethod(PaymentModel method)
        {
            return _bal.SavePaymentMethod(method);
        }

        [HttpGet]
        [Route("api/DeleteClaim")]
        public Result DeleteClaim(int ClaimId)
        {
            return _bal.DeleteClaim(ClaimId);
        }

        [HttpGet]
        [Route("api/GetClaim")]
        public ClaimModel GetClaim(int ClaimId)
        {
            return _bal.GetClaim(ClaimId);
        }

        [HttpGet]
        [Route("api/GetClaims")]
        public IEnumerable<ClaimModel> GetClaims(string PolicyCode)
        {
            return _bal.GetClaims(PolicyCode);
        }

        [HttpGet]
        [Route("api/SubmitClaim")]
        public Result SubmitClaim(int ClaimId, int PaymentMethodId)
        {
            return _bal.SubmitClaim(ClaimId, PaymentMethodId);
        }


        [HttpGet]
        [Route("api/GetPaymentMethods")]
        public IEnumerable<PaymentModel> GetPaymentMethod(string EmployeeCode)
        {
            return _bal.GetPaymentMethod(EmployeeCode);
        }

        [HttpGet]
        [Route("api/GetUserDetails")]
        public dynamic GetUserDetails()
        {
            ClaimsIdentity identity = HttpContext.Current.User.Identity as ClaimsIdentity;
            return new { EmployeeCode = identity.FindFirst("EmployeeCode").Value, PolicyCode = identity.FindFirst("PolicyCode").Value };
        }
    }
}
