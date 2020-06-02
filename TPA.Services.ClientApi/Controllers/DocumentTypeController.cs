using TPA.Common.Core.Model;
using TPA.Services.BusinessLogic;
using System.Net.Http;
using System.Web.Http;

namespace TPA.Services.ClientApi.Controllers
{
    public class DocumentTypeController : BaseApiController
    {
        private DocumentTypeBL _DocumentTypeRepo;
        public DocumentTypeController()
        {
            _DocumentTypeRepo = new DocumentTypeBL();
        }

        [HttpGet]
        [Route(URLs.DocumentType.Get)]
        public HttpResponseMessage Get()
        {
            return OKResponse(_DocumentTypeRepo.Get());
        }

        [HttpGet]
        [Route(URLs.DocumentType.GetById)]
        public HttpResponseMessage GetById(int DocumentTypeId)
        {
            return OKResponse(_DocumentTypeRepo.GetById(DocumentTypeId));
        }

        [HttpPost]
        [Route(URLs.DocumentType.Delete)]
        public HttpResponseMessage DeleteById(int DocumentTypeId)
        {
            return OKResponse(_DocumentTypeRepo.DeleteById(DocumentTypeId));
        }

        [HttpPost]
        [Route(URLs.DocumentType.Insert)]
        public HttpResponseMessage Insert(DocumentType obj)
        {
            return OKResponse(_DocumentTypeRepo.Insert(obj));
        }

        [HttpPost]
        [Route(URLs.DocumentType.Update)]
        public HttpResponseMessage Update(DocumentType obj)
        {
            return OKResponse(_DocumentTypeRepo.Update(obj));
        }
    }
}
