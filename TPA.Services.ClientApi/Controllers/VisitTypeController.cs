using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using TPA.Services.BusinessLogic;

namespace TPA.Services.ClientApi.Controllers
{
    public class VisitTypeController : BaseApiController
    {
        private VisitTypeBL _visitTypeBL;
        public VisitTypeController()
        {
            _visitTypeBL = new VisitTypeBL();
        }

        [HttpGet]
        [Route(URLs.VisitTypeURL.Get)]
        public HttpResponseMessage Get()
        {
            return OKResponse(_visitTypeBL.Get());
        }

        [HttpGet]
        [Route(URLs.VisitTypeURL.GET_BY_ID)]
        public HttpResponseMessage GetById(int visitTypeId)
        {
            return OKResponse(_visitTypeBL.GetById(visitTypeId));
        }
    }
}