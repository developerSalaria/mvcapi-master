using TPA.Common.Core.Constants;
using TPA.Common.Core.Helpers;
using TPA.Common.Core.Model;
using TPA.Common.Core.Services;
using System.Collections.Generic;

namespace TPA.Presentation.ApiServices
{
    public class GenderService : HttpClientService
    {
        public List<Gender> Get()
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Gender.Get);
            var Content = Get<List<Gender>>(URL);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return new List<Gender>();
            }
        }
        public Gender GetById(string genderId)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Gender.GetById, genderId);
            var Content = Get<Gender>(URL);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return new Gender() { ValidationMessage = new ValidationMessage() { Message = Content.Message } };
            }
        }
        public ValidationMessage Delete(int genderId)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Gender.Delete, genderId);
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
        public ValidationMessage Update(Gender obj)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Gender.Update);
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
        public ValidationMessage Insert(Gender obj)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Gender.Insert);
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