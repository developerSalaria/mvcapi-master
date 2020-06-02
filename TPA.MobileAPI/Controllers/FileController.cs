using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using TPA.Common.Core.MobileModel;
using TPA.Services.BusinessLogic.MobileBAL;

namespace TPA.MobileAPI.Controllers
{
    public class FileController : ApiController
    {
        ClaimBL _bal;
        FileController()
        {
            _bal = new ClaimBL();
        }

        [HttpPost]
        [Route("api/SaveFile")]
        public Result SaveFile()
        {
            try
            {
                Result result = new Result() { IsSuccess = false, Message = "Error" };
                FileModel file = new FileModel();
                var postedFileList = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files : null;

                if (postedFileList == null)
                    return null;

                for (int i = 0; i < postedFileList.Count; i++)
                {
                    var postedFile = postedFileList[i];
                    file.ClaimId = Convert.ToInt32(HttpContext.Current.Request.Form["ClaimId"]);
                    file.CreatedBy = Convert.ToInt32(HttpContext.Current.Request.Form["CreatedBy"]);

                    byte[] uploadedFile = new byte[postedFile.InputStream.Length];
                    postedFile.InputStream.Read(uploadedFile, 0, uploadedFile.Length);
                    file.Contents = Convert.ToBase64String(uploadedFile);
                    file.ContentType = postedFile.ContentType;
                    file.FileName = postedFile.FileName;
                    result = _bal.SaveFile(file);
                }

                return result;
            }
            catch (Exception ex)
            {
                return new Result() { IsSuccess = false, Message = ex.Message };
            }
        }

        [HttpGet]
        [Route("api/GetFiles")]
        public IEnumerable<FileModel> GetFiles(int ClaimId)
        {
            return _bal.GetFiles(ClaimId);
        }

        [HttpGet]
        [Route("api/GetFile")]
        public HttpResponseMessage GetFile(int FileId)
        {
            HttpResponseMessage result = null;
            try
            {
                FileModel file = _bal.GetFile(FileId);
                result = Request.CreateResponse(HttpStatusCode.OK);
                byte[] bytes = Convert.FromBase64String(file.Contents);
              
                result.Content = new StreamContent(new MemoryStream(bytes));
                result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);
                result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
                result.Content.Headers.ContentDisposition.FileName = file.FileName;
               
            }
            catch(Exception ex)
            {
                result = Request.CreateResponse(HttpStatusCode.Gone);
            }

            return result;

        }


    }
}
