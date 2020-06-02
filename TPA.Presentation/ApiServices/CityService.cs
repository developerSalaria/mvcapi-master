using TPA.Common.Core.Constants;
using TPA.Common.Core.Helpers;
using TPA.Common.Core.Model;
using TPA.Common.Core.Services;
using System.Collections.Generic;

namespace TPA.Presentation.ApiServices
{
    public class CityService : HttpClientService
    {
        public List<City> Get()
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.City.Get);
            var Content = Get<List<City>>(URL);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return new List<City>();
            }
        }
        public City GetById(string cityId)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.City.GetById, cityId);
            var Content = Get<City>(URL);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return new City() { ValidationMessage = new ValidationMessage() { Message = Content.Message } };
            }
        }
        public ValidationMessage Delete(int cityId)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.City.Delete, cityId);
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
        public ValidationMessage Update(City obj)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.City.Update);
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
        public ValidationMessage Insert(City obj)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.City.Insert);
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
