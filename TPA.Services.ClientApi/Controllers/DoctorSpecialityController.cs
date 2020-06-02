using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using TPA.Services.BusinessLogic;

namespace TPA.Services.ClientApi.Controllers
{
    public class DoctorSpecialityController : BaseApiController
    {
        private DoctorSpecialityBL _bl;
        public DoctorSpecialityController()
        {
            _bl = new DoctorSpecialityBL();
        }

        [HttpGet]
        [Route(URLs.DoctorSpecialityURL.Get)]
        public HttpResponseMessage Get()
        {
            return OKResponse(_bl.Get());
        }

        [HttpGet]
        [Route(URLs.DoctorSpecialityURL.GET_BY_ID)]
        public HttpResponseMessage GetById(int doctorSpecialityId)
        {
            return OKResponse(_bl.GetById(doctorSpecialityId));
        }
    }
}