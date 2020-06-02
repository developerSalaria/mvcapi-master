using TPA.Common.Core.Model;
using TPA.Services.BusinessLogic;
using System.Net.Http;
using System.Web.Http;

namespace TPA.Services.ClientApi.Controllers
{
    public class CustomerTypeController : BaseApiController
    {
        private CustomerTypeBL _customerTypeRepo;
        public CustomerTypeController()
        {
            _customerTypeRepo = new CustomerTypeBL();
        }

        [HttpGet]
        [Route(URLs.CustomerType.Get)]
        public HttpResponseMessage Get()
        {
            return OKResponse(_customerTypeRepo.Get());
        }

        [HttpGet]
        [Route(URLs.CustomerType.GetById)]
        public HttpResponseMessage GetById(int customerTypeId)
        {
            return OKResponse(_customerTypeRepo.GetById(customerTypeId));
        }

        [HttpPost]
        [Route(URLs.CustomerType.Delete)]
        public HttpResponseMessage DeleteById(int customerTypeId)
        {
            return OKResponse(_customerTypeRepo.DeleteById(customerTypeId));
        }

        [HttpPost]
        [Route(URLs.CustomerType.Insert)]
        public HttpResponseMessage Insert(CustomerType obj)
        {
            return OKResponse(_customerTypeRepo.Insert(obj));
        }

        [HttpPost]
        [Route(URLs.CustomerType.Update)]
        public HttpResponseMessage Update(CustomerType obj)
        {
            return OKResponse(_customerTypeRepo.Update(obj));
        }
    }
}
