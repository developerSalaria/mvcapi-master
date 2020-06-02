using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA.Common.Core.Model;

namespace TPA.Data.DAL.Repositories
{
    public class InsurancePolicyRepository : BaseRepository
    {
        public List<InsurancePolicy> Get()
        {
            return QueryExecutor.Query<InsurancePolicy>(SQLs.GET_ALL_INSURANCE_POLICIES, null, CommandType.Text).ToList();
        }
    }
}
