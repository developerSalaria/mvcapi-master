using TPA.Common.Core.Constants;
using TPA.Common.Core.Helpers;
using TPA.Common.Core.Model;
using TPA.Common.Core.Services;
using System.Collections.Generic;

namespace TPA.Presentation.ApiServices
{
    public class DocumentTypeService : HttpClientService
    {
        public List<DocumentType> Get()
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.DocumentType.Get);
            var Content = Get<List<DocumentType>>(URL);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return new List<DocumentType>();
            }
        }
        public DocumentType GetById(string DocumentTypeId)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.DocumentType.GetById, DocumentTypeId);
            var Content = Get<DocumentType>(URL);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return new DocumentType() { ValidationMessage = new ValidationMessage() { Message = Content.Message } };
            }
        }
        public ValidationMessage Delete(int DocumentTypeId)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.DocumentType.Delete, DocumentTypeId);
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
        public ValidationMessage Update(DocumentType obj)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.DocumentType.Update);
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
        public ValidationMessage Insert(DocumentType obj)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.DocumentType.Insert);
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
