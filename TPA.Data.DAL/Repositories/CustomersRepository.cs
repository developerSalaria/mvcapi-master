using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA.Common.Core.Model;

namespace TPA.Data.DAL.Repositories
{
    public class CustomersRepository : BaseRepository
    {
        public List<Policy> GetPolicies()
        {
            return QueryExecutor.Query<Policy>(StoreProcedures.USP_GetTPAPolicys.ToString(), null, CommandType.Text).ToList();
        }

        public List<CustomerInsured> GetCustomersInsured()
        {
            return QueryExecutor.Query<CustomerInsured>(StoreProcedures.USP_GetTPACustomersInsured.ToString(), null, CommandType.Text).ToList();
        }

        public List<SubPolicy> GetSubPoliciesByPolicyNo(string policyNo)
        {
            return QueryExecutor.Query<SubPolicy>(StoreProcedures.USP_GetTPASubPolicy.ToString(), new { @PolicyNo = policyNo }, CommandType.StoredProcedure).ToList();
        }

        public Policy GetPolicyByPolicyNo(string policyNo)
        {
            return QueryExecutor.Query<Policy>(StoreProcedures.USP_GetTPAPolicyByPolicyNo.ToString(), new { policyNo = policyNo }, CommandType.StoredProcedure).FirstOrDefault();
        }

        public int UpdatePolicy(Policy policy)
        {
            var obj = new
            {
                Action_Type = 102, // TODO: not sure if this is correct
                Id = policy.Id,
                PolicyNo = policy.PolicyNo,
                Contractor = policy.Contractor,
                ExpiryDate = policy.ExpiryDate,
                CreatedOn = DateTime.Now, // TODO: need to pass correct value
                CreatedBy = 1,
                UpdatedOn = DateTime.Now, // TODO: need to pass correct value
                UpdatedBy = 1,
            };
            DynamicParameters dynamicParameters = new DynamicParameters(obj);
            dynamicParameters.Add("@ID", dbType: DbType.Int32, direction: ParameterDirection.Output);
            return QueryExecutor.ExecuteWithReturnValue<int>(StoreProcedures.usp_GetTPAInsurancePolicy.ToString(), "ID", dynamicParameters, CommandType.StoredProcedure);

        }
    }
}
