using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA.Common.Core.Model;
using TPA.Data.DAL.Repositories;

namespace TPA.Services.BusinessLogic
{
    public class InsurancePolicyBL
    {
        private InsurancePolicyRepository _repo;
        public InsurancePolicyBL()
        {
            _repo = new InsurancePolicyRepository();
        }

        public List<InsurancePolicy> Get()
        {
            return _repo.Get();
        }
    }
}
