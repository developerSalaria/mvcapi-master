using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TPA.Common.Core.Constants;
using TPA.Common.Core.Helpers;
using TPA.Common.Core.Model;
using TPA.Common.Core.Services;
using TPAClaimServiceModel = TPA.Common.Core.Model.TPAClaimService;

namespace TPA.Presentation.ApiServices
{
    public class TPAClaimService : HttpClientService
    {
        static TPAClaimService _instance;

        public static TPAClaimService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TPAClaimService();
                }
                return _instance;
            }
        }

        public TPAClaim GetById(int claimId)
        {
            var URL = string.Format($"{AppSettings.BaseApiUrl}{ApiUrls.ClaimApiURL.Get}?claimId={claimId}");
            var Content = Get<TPAClaim>(URL);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return null;
            }
        }

        public int AddOrUpdateClaim(AddClaimModel addClaimModel)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.ClaimApiURL.INSERT);
            var Content = Post<int>(URL, addClaimModel);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return 0;
            }
        }

        public List<TPAClaim> GetByPolicyCode(string PolicyCode)
        {
            var URL = string.Format($"{AppSettings.BaseApiUrl}{ApiUrls.ClaimApiURL.GetByPolicyCode}?PolicyCode={PolicyCode}");
            var Content = Get<List<TPAClaim>>(URL);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return new List<TPAClaim>();
            }
        }

        public List<TPAClaimServiceBalance> GetServiceBalanceByPolicyCode(string PolicyCode)
        {
            var URL = string.Format($"{AppSettings.BaseApiUrl}{ApiUrls.ClaimApiURL.GetServiceBalanceByPolicyCode}?PolicyCode={PolicyCode}");
            var Content = Get<List<TPAClaimServiceBalance>>(URL);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return new List<TPAClaimServiceBalance>();
            }
        }


        public List<ServiceType> GetClaimServices(int claimId)
        {
            var URL = string.Format($"{AppSettings.BaseApiUrl}{ApiUrls.ClaimApiURL.GET_CLAIM_SERVICES}?claimId={claimId}");
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


        public List<Symptoms> GetClaimSymptoms(int claimId)
        {
            var URL = string.Format($"{AppSettings.BaseApiUrl}{ApiUrls.ClaimApiURL.GET_CLAIM_SYMPTOMS}?claimId={claimId}");
            var Content = Get<List<Symptoms>>(URL);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return new List<Symptoms>();
            }
        }


        public List<ClaimListModel> GetAllClaims(ReportSearchModel reportSearchModel)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.ClaimApiURL.GetAllClaims);
            var Content = Post<List<ClaimListModel>>(URL, reportSearchModel);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return new List<ClaimListModel>();
            }
        }


        public List<Symptoms> SearchSymtoms(string  symptom)
        {
            var URL = string.Format($"{AppSettings.BaseApiUrl}{ApiUrls.ClaimApiURL.GET_SYMPTOMS}?symptom={symptom}");
            var Content = Get<List<Symptoms>>(URL);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return new List<Symptoms>();
            }
        }
    }
}