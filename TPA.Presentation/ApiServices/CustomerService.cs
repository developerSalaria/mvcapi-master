using TPA.Common.Core.Constants;
using TPA.Common.Core.Helpers;
using TPA.Common.Core.Model;
using TPA.Common.Core.Services;
using System.Collections.Generic;

namespace TPA.Presentation.ApiServices
{
    public class CustomerService : HttpClientService
    {
        public List<Customer> Get()
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Customer.Get);
            var Content = Get<List<Customer>>(URL);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return new List<Customer>();
            }
        }

        public CustomerViewModel CustomerDataTable(Customer obj)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Customer.CustomerDataTable);
            var Content = Post<CustomerViewModel>(URL, obj);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return new CustomerViewModel() { ValidationMessage = new ValidationMessage() { Message = Content.Message } };
            }
        }

        public Customer GetById(int customerId)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Customer.GetById, customerId);
            var Content = Get<Customer>(URL);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return new Customer() { ValidationMessage = new ValidationMessage() { Message = Content.Message } };
            }
        }
        public ValidationMessage Delete(int customerId)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Customer.Delete, customerId);
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
        public ValidationMessage Update(Customer obj)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Customer.Update);
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
        public ValidationMessage Insert(Customer obj)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Customer.Insert);
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