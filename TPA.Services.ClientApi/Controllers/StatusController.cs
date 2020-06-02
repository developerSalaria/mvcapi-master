using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using TPA.Services.BusinessLogic;

namespace TPA.Services.ClientApi.Controllers
{
    public class StatusController : BaseApiController
    {
        private StatusBL _bl;
        public StatusController()
        {
            _bl = new StatusBL();
        }

        [HttpGet]
        [Route(URLs.StatusURL.Get)]
        public HttpResponseMessage Get()
        {
            return OKResponse(_bl.Get());
        }

        [HttpGet]
        [Route(URLs.StatusURL.GET_BY_ID)]
        public HttpResponseMessage GetById(int statusId)
        {
            return OKResponse(_bl.GetById(statusId));
        }
    }
}