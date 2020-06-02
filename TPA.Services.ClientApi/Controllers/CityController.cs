using TPA.Common.Core.Model;
using TPA.Services.BusinessLogic;
using System.Net.Http;
using System.Web.Http;

namespace TPA.Services.ClientApi.Controllers
{
    public class CityController : BaseApiController
    {
        private CityBL _cityRepo;
        public CityController()
        {
            _cityRepo = new CityBL();
        }

        [HttpGet]
        [Route(URLs.City.Get)]
        public HttpResponseMessage Get()
        {
            return OKResponse(_cityRepo.Get());
        }

        [HttpGet]
        [Route(URLs.City.GetById)]
        public HttpResponseMessage GetById(int cityId)
        {
            return OKResponse(_cityRepo.GetById(cityId));
        }

        [HttpPost]
        [Route(URLs.City.Delete)]
        public HttpResponseMessage DeleteById(int cityId)
        {
            return OKResponse(_cityRepo.DeleteById(cityId));
        }

        [HttpPost]
        [Route(URLs.City.Insert)]
        public HttpResponseMessage Insert(City obj)
        {
            return OKResponse(_cityRepo.Insert(obj));
        }

        [HttpPost]
        [Route(URLs.City.Update)]
        public HttpResponseMessage Update(City obj)
        {
            return OKResponse(_cityRepo.Update(obj));
        }
    }
}
