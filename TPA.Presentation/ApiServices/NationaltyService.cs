using TPA.Common.Core.Constants;
using TPA.Common.Core.Helpers;
using TPA.Common.Core.Model;
using TPA.Common.Core.Services;
using System.Collections.Generic;

namespace TPA.Presentation.ApiServices
{
    public class NationaltyService : HttpClientService
    {
        public List<Nationalty> Get()
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Nationalty.Get);
            var Content = Get<List<Nationalty>>(URL);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return new List<Nationalty>();
            }
        }
        public Nationalty GetById(string nationaltyId)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Nationalty.GetById, nationaltyId);
            var Content = Get<Nationalty>(URL);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return new Nationalty() { ValidationMessage = new ValidationMessage() { Message = Content.Message } };
            }
        }
        public ValidationMessage Delete(int nationaltyId)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Nationalty.Delete, nationaltyId);
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
        public ValidationMessage Update(Nationalty obj)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Nationalty.Update);
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
        public ValidationMessage Insert(Nationalty obj)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Nationalty.Insert);
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