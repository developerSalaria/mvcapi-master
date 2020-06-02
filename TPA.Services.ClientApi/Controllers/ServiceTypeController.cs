using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using TPA.Services.BusinessLogic;

namespace TPA.Services.ClientApi.Controllers
{
    public class ServiceTypeController : BaseApiController
    {
        private ServiceTypeBL _bl;
        public ServiceTypeController()
        {
            _bl = new ServiceTypeBL();
        }

        [HttpGet]
        [Route(URLs.ServiceTypeURL.Get)]
        public HttpResponseMessage Get(string policycode)
        {
            return OKResponse(_bl.Get(policycode));
        }


        [HttpGet]
        [Route(URLs.ServiceTypeURL.GET_PROVIDER_SERVICES)]
        public HttpResponseMessage GetProviderServices(int providerId)
        {
            return OKResponse(_bl.GetProviderServices(providerId));
        }  
    }
}