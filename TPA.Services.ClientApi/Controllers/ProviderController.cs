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
    public class ProviderController : BaseApiController
    {
        private ProviderBL _providerRepo;
        public ProviderController()
        {
            _providerRepo = new ProviderBL();
        }

        [HttpGet]
        [Route(URLs.ProviderURL.Get)]
        public HttpResponseMessage Get()
        {
            return OKResponse(_providerRepo.Get());
        }

        [HttpGet]
        [Route(URLs.ProviderURL.GET_BY_ID)]
        public HttpResponseMessage GetById(int providerId)
        {
            return OKResponse(_providerRepo.GetById(providerId));
        }


        [HttpPost]
        [Route(URLs.ProviderURL.INSERT)]
        public HttpResponseMessage AddProvider(Provider provider)
        {
            return OKResponse(_providerRepo.AddProvider(provider));
        }
    }
}