using TPA.Common.Core.Constants;
using TPA.Common.Core.Helpers;
using TPA.Common.Core.Model;
using TPA.Common.Core.Services;
using System.Collections.Generic;

namespace TPA.Presentation.ApiServices
{
    public class CustomerDocumentService : HttpClientService
    {
        public List<CustomerDocument> Get()
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.CustomerDocument.Get);
            var Content = Get<List<CustomerDocument>>(URL);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return new List<CustomerDocument>();
            }
        }
        public CustomerDocument GetById(string customerDocumentId)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.CustomerDocument.GetById, customerDocumentId);
            var Content = Get<CustomerDocument>(URL);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return new CustomerDocument() { ValidationMessage = new ValidationMessage() { Message = Content.Message } };
            }
        }
        public ValidationMessage Delete(int customerDocumentId)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.CustomerDocument.Delete, customerDocumentId);
            var Content = Post<string>(URL);
            if (Content.IsSuccessful)
            {
                return new ValidationMessage();
            }
            else
            {
                return new ValidationMessage() { Message = Content.Message };
            }
        }
        public ValidationMessage Update(CustomerDocument obj)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.CustomerDocument.Update);
            var Content = Post<string>(URL, obj);
            if (Content.IsSuccessful)
            {
                return new ValidationMessage();
            }
            else
            {
                return new ValidationMessage() { Message = Content.Message };
            }
        }
        public ValidationMessage Insert(CustomerDocument obj)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.CustomerDocument.Insert);
            var Content = Post<string>(URL, obj);
            if (Content.IsSuccessful)
            {
                return new ValidationMessage();
            }
            else
            {
                return new ValidationMessage() { Message = Content.Message };
            }
        }
    }
}