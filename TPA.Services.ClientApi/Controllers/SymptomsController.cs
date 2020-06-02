using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using TPA.Services.BusinessLogic;

namespace TPA.Services.ClientApi.Controllers
{
    public class SymptomsController : BaseApiController
    {

        private SymptomsBL _bl;
        public SymptomsController()
        {
            _bl = new SymptomsBL();
        }

        [HttpGet]
        [Route(URLs.SymptomsURL.Get)]
        public HttpResponseMessage Get()
        {
            return OKResponse(_bl.Get());
        }

        [HttpGet]
        [Route(URLs.SymptomsURL.Get)]
        public HttpResponseMessage Get(string symptom)
        {
            return OKResponse(_bl.Get(symptom));
        }
    }
}