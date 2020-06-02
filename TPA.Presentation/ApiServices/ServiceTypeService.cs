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
    public class ServiceTypeService : HttpClientService
    {
        static ServiceTypeService _instance;

        public static ServiceTypeService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ServiceTypeService();
                }
                return _instance;
            }
        }

        public List<ServiceType> Get(string policycode)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.ServiceTypeApiURL.Get + $"?policycode={policycode}");
            var Content = Get<List<ServiceType>>(URL);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return new List<ServiceType>();
            }
        }

        public List<ServiceType> GetProviderServices(int providerId)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.ServiceTypeApiURL.GET_PROVIDER_SERVICES + $"?providerId={providerId}");
            var Content = Get<List<ServiceType>>(URL);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return new List<ServiceType>();
            }
        }
    }
}