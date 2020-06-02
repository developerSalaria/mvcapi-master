using TPA.Common.Core.Constants;
using TPA.Services.ClientApi.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace TPA.Services.ClientApi.Controllers
{
    [CustomExceptionFilter]
    [Authorize]
    public class BaseApiController : ApiController
    {
        public string UserId { get { return HttpContext.Current.Request.Headers["userId"]; }  }
        protected string GetErrorMessages()
        {
            return string.Join(", ", ModelState.Values.Where(x => x.Errors.Count > 0).SelectMany(x => x.Errors).SelectMany(x => x.ErrorMessage).ToArray());
        }

        protected new virtual HttpResponseMessage BadRequest(string errorMessage)
        {
            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.BadRequest,
                Content = new StringContent(errorMessage, Encoding.UTF8, MimeTypes.PLAIN)
            };
        }

        protected virtual HttpResponseMessage OK(string response)
        {
            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(response), Encoding.UTF8, MimeTypes.JSON)
            };
        }

        protected virtual HttpResponseMessage OKResponse(object response)
        {
            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new ObjectContent(response.GetType(), response, new JsonMediaTypeFormatter(), MimeTypes.JSON)
            };
        }
    }
}
