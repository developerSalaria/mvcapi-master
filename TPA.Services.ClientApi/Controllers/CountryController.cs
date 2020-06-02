using TPA.Common.Core.Model;
using TPA.Services.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TPA.Services.ClientApi.Controllers
{
    public class CountryController : BaseApiController
    {
        private CountryBL _countryRepo;
        public CountryController()
        {
            _countryRepo = new CountryBL();
        }

        [HttpGet]
        [Route(URLs.Country.Get)]
        public HttpResponseMessage Get()
        {
            return OKResponse(_countryRepo.Get());
        }

        [HttpGet]
        [Route(URLs.Country.GetById)]
        public HttpResponseMessage GetById(int countryId)
        {
            return OKResponse(_countryRepo.GetById(countryId));
        }

        [HttpPost]
        [Route(URLs.Country.Delete)]
        public HttpResponseMessage DeleteById(int countryId)
        {
            return OKResponse(_countryRepo.DeleteById(countryId));
        }

        [HttpPost]
        [Route(URLs.Country.Insert)]
        public HttpResponseMessage Insert(Country obj)
        {
            return OKResponse(_countryRepo.Insert(obj));
        }

        [HttpPost]
        [Route(URLs.Country.Update)]
        public HttpResponseMessage Update(Country obj)
        {
            return OKResponse(_countryRepo.Update(obj));
        }
    }
}
