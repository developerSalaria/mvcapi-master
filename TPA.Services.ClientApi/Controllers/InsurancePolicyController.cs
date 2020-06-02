using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using TPA.Services.BusinessLogic;

namespace TPA.Services.ClientApi.Controllers
{
    public class InsurancePolicyController : BaseApiController
    {
        private InsurancePolicyBL _bl;
        public InsurancePolicyController()
        {
            _bl = new InsurancePolicyBL();
        }

        [HttpGet]
        [Route(URLs.InsurancePolicyURL.Get)]
        public HttpResponseMessage Get()
        {
            return OKResponse(_bl.Get());
        }
    }
}