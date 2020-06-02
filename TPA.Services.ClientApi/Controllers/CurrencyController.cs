using TPA.Common.Core.Model;
using TPA.Services.BusinessLogic;
using System.Net.Http;
using System.Web.Http;

namespace TPA.Services.ClientApi.Controllers
{
    public class CurrencyController : BaseApiController
    {
        private CurrencyBL _currencyRepo;
        public CurrencyController()
        {
            _currencyRepo = new CurrencyBL();
        }

        [HttpGet]
        [Route(URLs.Currency.Get)]
        public HttpResponseMessage Get()
        {
            return OKResponse(_currencyRepo.Get());
        }

        [HttpGet]
        [Route(URLs.Currency.GetById)]
        public HttpResponseMessage GetById(int currencyId)
        {
            return OKResponse(_currencyRepo.GetById(currencyId));
        }

        [HttpPost]
        [Route(URLs.Currency.Delete)]
        public HttpResponseMessage DeleteById(int currencyId)
        {
            return OKResponse(_currencyRepo.DeleteById(currencyId));
        }

        [HttpPost]
        [Route(URLs.Currency.Insert)]
        public HttpResponseMessage Insert(Currency obj)
        {
            return OKResponse(_currencyRepo.Insert(obj));
        }

        [HttpPost]
        [Route(URLs.Currency.Update)]
        public HttpResponseMessage Update(Currency obj)
        {
            return OKResponse(_currencyRepo.Update(obj));
        }
    }
}
