using TPA.Common.Core.Constants;
using TPA.Common.Core.Helpers;
using TPA.Common.Core.Model;
using TPA.Common.Core.Services;
using System.Collections.Generic;

namespace TPA.Presentation.ApiServices
{
    public class CustomerTypeService : HttpClientService
    {
        public List<CustomerType> Get()
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.CustomerType.Get);
            var Content = Get<List<CustomerType>>(URL);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return new List<CustomerType>();
            }
        }
        public CustomerType GetById(string customerTypeId)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.CustomerType.GetById, customerTypeId);
            var Content = Get<CustomerType>(URL);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return new CustomerType() { ValidationMessage = new ValidationMessage() { Message = Content.Message } };
            }
        }
        public ValidationMessage Delete(int customerTypeId)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.CustomerType.Delete, customerTypeId);
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
        public ValidationMessage Update(CustomerType obj)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.CustomerType.Update);
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
        public ValidationMessage Insert(CustomerType obj)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.CustomerType.Insert);
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