using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TPA.Common.Core.Constants;
using TPA.Common.Core.Helpers;
using TPA.Common.Core.Model;
using TPA.Common.Core.Services;

namespace TPA.Presentation.ApiServices
{
    public class ProviderService : HttpClientService
    {
       static ProviderService _instance;

        public static ProviderService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ProviderService();
                }
                return _instance;
            }
        }

        public List<Provider> Get()
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.ProviderApiURL.Get);
            var Content = Get<List<Provider>>(URL);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return new List<Provider>();
            }
        }

        /// <summary>
        /// Get By Id
        /// </summary>
        /// <param name="providerId"></param>
        /// <returns></returns>
        public Provider GetById(int providerId)
        {
            var URL = string.Format($"{AppSettings.BaseApiUrl}{ApiUrls.ProviderApiURL.GET_BY_ID}?providerId={providerId}");
            var Content = Get<Provider>(URL);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Add Or Update Provider
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        public int AddOrUpdateProvider(Provider provider)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.CustomersApiURL.UpdatePolicy);
            var Content = Post<int>(URL, provider);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return 0;
            }
        }
    }
}