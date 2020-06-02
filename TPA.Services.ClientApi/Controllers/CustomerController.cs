using TPA.Common.Core.Model;
using TPA.Services.BusinessLogic;
using System;
using System.Net.Http;
using System.Web.Http;

namespace TPA.Services.ClientApi.Controllers
{
    public class CustomerController : BaseApiController
    {
        private CustomerBL _customerRepo;
        public CustomerController()
        {
            _customerRepo = new CustomerBL();
        }

        [HttpGet]
        [Route(URLs.Customer.Get)]
        public HttpResponseMessage Get()
        {
            return OKResponse(_customerRepo.Get());
        }

        [HttpPost]
        [Route(URLs.Customer.CustomerDataTable)]
        public HttpResponseMessage CustomerDataTable(Customer c)
        {
            return OKResponse(_customerRepo.CustomerDataTable(c));
        }

        [HttpGet]
        [Route(URLs.Customer.GetById)]
        public HttpResponseMessage GetById(int id)
        {
            return OKResponse(_customerRepo.GetById(id));
        }

        [HttpPost]
        [Route(URLs.Customer.Delete)]
        public HttpResponseMessage DeleteById(int id)
        {
            return OKResponse(_customerRepo.DeleteById(id));
        }

        [HttpPost]
        [Route(URLs.Customer.Insert)]
        public HttpResponseMessage Insert(Customer obj)
        {
            obj.UpdatedBy = UserId;
            obj.CreatedBy = UserId;
            obj.CreatedOn =DateTime.Now;
            obj.UpdatedOn = DateTime.Now;
            return OKResponse(_customerRepo.Insert(obj));
        }

        [HttpPost]
        [Route(URLs.Customer.Update)]
        public HttpResponseMessage Update(Customer obj)
        {
            obj.UpdatedBy = UserId;
            obj.CreatedBy = UserId;
            obj.CreatedOn = DateTime.Now;
            obj.UpdatedOn = DateTime.Now;
            return OKResponse(_customerRepo.Update(obj));
        }
    }
}
