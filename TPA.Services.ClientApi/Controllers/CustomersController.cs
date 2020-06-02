using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using TPA.Common.Core.Model;
using TPA.Services.BusinessLogic;

namespace TPA.Services.ClientApi.Controllers
{
    [Authorize]
    public class CustomersController : BaseApiController
    {
        private CustomersBL _customersBL;
        public CustomersController()
        {
            _customersBL = new CustomersBL();
        }

        [HttpGet]
        [Route(URLs.CustomersURL.GetPolicies)]
        public HttpResponseMessage GetPolicies()
        {
            return OKResponse(_customersBL.GetPolicies());
        }

        [HttpGet]
        [Route(URLs.CustomersURL.GetCustomersInsured)]
        public HttpResponseMessage GetCustomersInsured()
        {
            return OKResponse(_customersBL.GetCustomersInsured());
        }


        [HttpGet]
        [Route(URLs.CustomersURL.GetSubPoliciesByPolicyNo)]
        public HttpResponseMessage GetSubPoliciesByPolicyNo(string policyNo)
        {
            return OKResponse(_customersBL.GetSubPoliciesByPolicyNo(policyNo));
        }


        [HttpGet]
        [Route(URLs.CustomersURL.GetPolicyByPolicyNo)]
        public HttpResponseMessage GetPolicyByPolicyNo(string policyNo)
        {
            return OKResponse(_customersBL.GetPolicyByPolicyNo(policyNo));
        }

        [HttpPost]
        [Route(URLs.CustomersURL.UpdatePolicy)]
        public HttpResponseMessage UpdatePolicy(Policy policy)
        {
            return OKResponse(_customersBL.UpdatePolicy(policy));
        }
    }
}