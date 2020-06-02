using TPA.Common.Core.Constants;
using TPA.Common.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http.Filters;

namespace TPA.Services.ClientApi.Helpers
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var ResponseModel = new BaseModel();

            HttpStatusCode status = HttpStatusCode.InternalServerError;
            string message = String.Empty;
            var exceptionType = actionExecutedContext.Exception.GetType();
            if (exceptionType == typeof(UnauthorizedAccessException))
            {
                message = "Access to the Web API is not authorized.";
                status = HttpStatusCode.Unauthorized;
            }
            else if (exceptionType == typeof(DivideByZeroException))
            {
                message = "Internal Server Error.";
                status = HttpStatusCode.InternalServerError;
            }
            else if (exceptionType == typeof(SqlException))
            {
                message = "Exception From Database";
                status = HttpStatusCode.InternalServerError;
            }
            else if (exceptionType == typeof(ArgumentNullException))
            {
                message = "Internal Server Error.";
                status = HttpStatusCode.InternalServerError;
            }
            else
            {
                message = "Not found.";
                status = HttpStatusCode.NotFound;
            }

            ResponseModel.ValidationMessage.Message = message;
            ResponseModel.ValidationMessage.ErrorCode = status;

            actionExecutedContext.Response = new HttpResponseMessage()
            {
                Content = new ObjectContent(ResponseModel.GetType(), ResponseModel, new JsonMediaTypeFormatter(), MimeTypes.JSON),
                StatusCode = status
            };
            base.OnException(actionExecutedContext);
        }
    }
}