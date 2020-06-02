using TPA.Common.Core.Constants;
using TPA.Common.Core.Helpers;
using TPA.Common.Core.Model;
using TPA.Common.Core.Services;
using System.Collections.Generic;

namespace TPA.Presentation.ApiServices
{
    public class CurrencyService : HttpClientService
    {
        public List<Currency> Get()
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Currency.Get);
            var Content = Get<List<Currency>>(URL);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return new List<Currency>();
            }
        }
        public Currency GetById(string currencyId)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Currency.GetById, currencyId);
            var Content = Get<Currency>(URL);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return new Currency() { ValidationMessage = new ValidationMessage() { Message = Content.Message } };
            }
        }
        public ValidationMessage Delete(int currencyId)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Currency.Delete, currencyId);
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
        public ValidationMessage Update(Currency obj)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Currency.Update);
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
        public ValidationMessage Insert(Currency obj)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Currency.Insert);
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