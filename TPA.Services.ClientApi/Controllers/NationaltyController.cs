using TPA.Common.Core.Model;
using TPA.Services.BusinessLogic;
using System.Net.Http;
using System.Web.Http;

namespace TPA.Services.ClientApi.Controllers
{
    public class NationaltyController : BaseApiController
    {
        private NationaltyBL _nationaltyRepo;
        public NationaltyController()
        {
            _nationaltyRepo = new NationaltyBL();
        }

        [HttpGet]
        [Route(URLs.Nationalty.Get)]
        public HttpResponseMessage Get()
        {
            return OKResponse(_nationaltyRepo.Get());
        }

        [HttpGet]
        [Route(URLs.Nationalty.GetById)]
        public HttpResponseMessage GetById(int nationaltyId)
        {
            return OKResponse(_nationaltyRepo.GetById(nationaltyId));
        }

        [HttpPost]
        [Route(URLs.Nationalty.Delete)]
        public HttpResponseMessage DeleteById(int nationaltyId)
        {
            return OKResponse(_nationaltyRepo.DeleteById(nationaltyId));
        }

        [HttpPost]
        [Route(URLs.Nationalty.Insert)]
        public HttpResponseMessage Insert(Nationalty obj)
        {
            return OKResponse(_nationaltyRepo.Insert(obj));
        }

        [HttpPost]
        [Route(URLs.Nationalty.Update)]
        public HttpResponseMessage Update(Nationalty obj)
        {
            return OKResponse(_nationaltyRepo.Update(obj));
        }
    }
}
