using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA.Common.Core.Model;
using TPA.Data.DAL.Repositories;

namespace TPA.Services.BusinessLogic
{
    public class TPAClaimBL
    {
        private TPAClaimRepository _repo;
        public TPAClaimBL()
        {
            _repo = new TPAClaimRepository();
        }

        public List<TPAClaim> GetByPolicyCode(string PolicyCode)
        {
            return _repo.GetByPolicyCode(PolicyCode);
        }

        public List<TPAClaimServiceBalance> GetServiceBalanceByPolicyCode(string PolicyCode)
        {
            return _repo.GetServiceBalanceByPolicyCode(PolicyCode);
        }

        public TPAClaim GetById(string claimId)
        {
            return _repo.GetById(claimId);
        }

        public int AddClaim(AddClaimModel claimModel)
        {
            return _repo.AddClaim(claimModel.Claim, claimModel.Services, claimModel.Symptoms);
        }

        public List<ClaimListModel> GetAllClaims(ReportSearchModel reportSearchModel)
        {
            return _repo.GetAllClaims(reportSearchModel);
        }

        public List<ServiceType> GetClaimServices(int claimId)
        {
            return _repo.GetClaimServices(claimId);

        }

        public List<Symptoms> GetClaimSymptoms(int claimId)
        {
            return _repo.GetClaimSymptoms(claimId);
        }
    }
}
