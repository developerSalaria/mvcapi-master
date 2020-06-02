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
    public class InsurancePolicyService : HttpClientService
    {
        static InsurancePolicyService _instance;

        public static InsurancePolicyService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new InsurancePolicyService();
                }
                return _instance;
            }
        }

        public List<InsurancePolicy> Get()
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.InsurancePolicyApiURL.Get);
            var Content = Get<List<InsurancePolicy>>(URL);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return new List<InsurancePolicy>();
            }
        }
    }
}