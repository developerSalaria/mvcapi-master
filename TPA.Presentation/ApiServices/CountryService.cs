using TPA.Common.Core.Constants;
using TPA.Common.Core.Helpers;
using TPA.Common.Core.Model;
using TPA.Common.Core.Services;
using System.Collections.Generic;

namespace TPA.Presentation.ApiServices
{
    public class CountryService : HttpClientService
    {
        public List<Country> Get()
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Country.Get);
            var Content = Get<List<Country>>(URL);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return new List<Country>();
            }
        }
        public Country GetById(string countryId)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Country.GetById, countryId);
            var Content = Get<Country>(URL);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return new Country() { ValidationMessage = new ValidationMessage() { Message = Content.Message } };
            }
        }
        public ValidationMessage Delete(int countryId)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Country.Delete, countryId);
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
        public ValidationMessage Update(Country obj)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Country.Update);
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
        public ValidationMessage Insert(Country obj)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Country.Insert);
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