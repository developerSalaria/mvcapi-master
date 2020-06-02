using TPA.Common.Core.Model;
using TPA.Services.BusinessLogic;
using System.Net.Http;
using System.Web.Http;

namespace TPA.Services.ClientApi.Controllers
{
    public class CustomerDocumentController : BaseApiController
    {
        private CustomerDocumentBL _customerDocumentRepo;
        public CustomerDocumentController()
        {
            _customerDocumentRepo = new CustomerDocumentBL();
        }

        [HttpGet]
        [Route(URLs.CustomerDocument.Get)]
        public HttpResponseMessage Get()
        {
            return OKResponse(_customerDocumentRepo.Get());
        }

        [HttpGet]
        [Route(URLs.CustomerDocument.GetById)]
        public HttpResponseMessage GetById(int customerDocumentId)
        {
            return OKResponse(_customerDocumentRepo.GetById(customerDocumentId));
        }

        [HttpPost]
        [Route(URLs.CustomerDocument.Delete)]
        public HttpResponseMessage DeleteById(int customerDocumentId)
        {
            return OKResponse(_customerDocumentRepo.DeleteById(customerDocumentId));
        }

        [HttpPost]
        [Route(URLs.CustomerDocument.Insert)]
        public HttpResponseMessage Insert(CustomerDocument obj)
        {
            return OKResponse(_customerDocumentRepo.Insert(obj));
        }

        [HttpPost]
        [Route(URLs.CustomerDocument.Update)]
        public HttpResponseMessage Update(CustomerDocument obj)
        {
            return OKResponse(_customerDocumentRepo.Update(obj));
        }
    }
}
