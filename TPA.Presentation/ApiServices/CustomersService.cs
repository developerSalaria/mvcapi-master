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
    public class CustomersService : HttpClientService
    {
       static CustomersService _instance;

        public static CustomersService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CustomersService();
                }
                return _instance;
            }
        }

        /// <summary>
        /// Get Policies List
        /// </summary>
        /// <returns></returns>
        public List<Policy> GetPolicies()
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.CustomersApiURL.GetPolicies);
            var Content = Get<List<Policy>>(URL);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return new List<Policy>();
            }
        }

        /// <summary>
        /// Get Customers Insured List
        /// </summary>
        /// <returns></returns>
        public List<CustomerInsured> GetCustomersInsured()
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.CustomersApiURL.GetCustomersInsured);
            var Content = Get<List<CustomerInsured>>(URL);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return new List<CustomerInsured>();
            }
        }

        /// <summary>
        /// Get Sub Policies By Policy No
        /// </summary>
        /// <param name="policyNo"></param>
        /// <returns></returns>
        public List<SubPolicy> GetSubPoliciesByPolicyNo(string policyNo)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.CustomersApiURL.GetSubPoliciesByPolicyNo + $"?policyNo={policyNo}");
            var Content = Get<List<SubPolicy>>(URL);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return new List<SubPolicy>();
            }
        }

        /// <summary>
        /// Get Policy By Policy No
        /// </summary>
        /// <param name="policyNo"></param>
        /// <returns></returns>
        public Policy GetPolicyByPolicyNo(string policyNo)
        {
            var URL = string.Format($"{AppSettings.BaseApiUrl}{ApiUrls.CustomersApiURL.GetPolicyByPolicyNo}?policyNo={policyNo}");
            var Content = Get<Policy>(URL);
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
        /// Add Or Update Policy
        /// </summary>
        /// <param name="policy"></param>
        /// <returns></returns>
        public int UpdatePolicy(Policy policy)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.CustomersApiURL.UpdatePolicy);
            var Content = Post<int>(URL, policy);
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