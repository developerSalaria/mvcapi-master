using TPA.Common.Core.Model;
using TPA.Services.BusinessLogic;
using System.Net.Http;
using System.Web.Http;

namespace TPA.Services.ClientApi.Controllers
{
    public class GenderController : BaseApiController
    {
        private GenderBL _genderRepo;
        public GenderController()
        {
            _genderRepo = new GenderBL();
        }

        [HttpGet]
        [Route(URLs.Gender.Get)]
        public HttpResponseMessage Get()
        {
            return OKResponse(_genderRepo.Get());
        }

        [HttpGet]
        [Route(URLs.Gender.GetById)]
        public HttpResponseMessage GetById(int genderId)
        {
            return OKResponse(_genderRepo.GetById(genderId));
        }

        [HttpPost]
        [Route(URLs.Gender.Delete)]
        public HttpResponseMessage DeleteById(int genderId)
        {
            return OKResponse(_genderRepo.DeleteById(genderId));
        }

        [HttpPost]
        [Route(URLs.Gender.Insert)]
        public HttpResponseMessage Insert(Gender obj)
        {
            return OKResponse(_genderRepo.Insert(obj));
        }

        [HttpPost]
        [Route(URLs.Gender.Update)]
        public HttpResponseMessage Update(Gender obj)
        {
            return OKResponse(_genderRepo.Update(obj));
        }
    }
}
