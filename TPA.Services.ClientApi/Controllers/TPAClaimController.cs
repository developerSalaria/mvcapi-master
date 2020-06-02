using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using TPA.Common.Core.Model;
using TPA.Services.BusinessLogic;

namespace TPA.Services.ClientApi.Controllers
{
    public class TPAClaimController : BaseApiController
    {
        private TPAClaimBL _repo;
        public TPAClaimController()
        {
            _repo = new TPAClaimBL();
        }

        [HttpGet]
        [Route(URLs.ClaimURL.GetByPolicyCode)]
        public HttpResponseMessage GetByPolicyCode(string PolicyCode)
        {
            return OKResponse(_repo.GetByPolicyCode(PolicyCode));
        }

        [HttpGet]
        [Route(URLs.ClaimURL.GetServiceBalanceByPolicyCode)]
        public HttpResponseMessage GetServiceBalanceByPolicyCode(string PolicyCode)
        {
            return OKResponse(_repo.GetServiceBalanceByPolicyCode(PolicyCode));
        }

        [HttpGet]
        [Route(URLs.ClaimURL.Get)]
        public HttpResponseMessage GetById(string claimId)
        {
            return OKResponse(_repo.GetById(claimId));
        }

        [HttpPost]
        [Route(URLs.ClaimURL.INSERT)]
        public HttpResponseMessage AddClaim(AddClaimModel claimModel)
        {
            return OKResponse(_repo.AddClaim(claimModel));
        }

        [HttpPost]
        [Route(URLs.ClaimURL.GetAllClaims)]
        public HttpResponseMessage GetAllClaims(ReportSearchModel reportSearchModel)
        {
            return OKResponse(_repo.GetAllClaims(reportSearchModel));
        }

        [HttpGet]
        [Route(URLs.ClaimURL.GET_CLAIM_SERVICES)]
        public HttpResponseMessage GetClaimServices(int claimId)
        {
            return OKResponse(_repo.GetClaimServices(claimId));
        }

        [HttpGet]
        [Route(URLs.ClaimURL.GET_CLAIM_SYMPTOMS)]
        public HttpResponseMessage GetClaimSymptoms(int claimId)
        {
            return OKResponse(_repo.GetClaimSymptoms(claimId));
        }
    }
}