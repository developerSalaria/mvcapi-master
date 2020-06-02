using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using TPA.Common.Core.Model;
using TPA.Services.BusinessLogic;

namespace TPA.Services.ClientApi.Controllers
{
    public class FileController : BaseApiController
    {
        private FileBL _repo;
        public FileController()
        {
            _repo = new FileBL();
        }

        [HttpPost]
        [Route(URLs.FileURL.SAVE_FILE)]

        public HttpResponseMessage SaveFile(FileData fileData)
        {
            return OKResponse(_repo.SaveFile(fileData));
        }

        [HttpGet]
        [Route(URLs.FileURL.GET_FILE)]

        public HttpResponseMessage GetFile(int fileId)
        {
            return OKResponse(_repo.GetFile(fileId));
        }
    }
}