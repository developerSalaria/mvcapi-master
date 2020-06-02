using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA.Common.Core.Model;

namespace TPA.Data.DAL.Repositories
{
    public class ServiceTypeRepository : BaseRepository
    {
        public List<ServiceType> Get(string policycode)
        {
            if(string.IsNullOrEmpty(policycode))
                return QueryExecutor.Query<ServiceType>(SQLs.GET_ALL_SERVICE_TYPES.ToString(), null, CommandType.Text).ToList();
            else
            return QueryExecutor.Query<ServiceType>(SQLs.GET_ALL_SERVICE_TYPES_BYPOLICY.ToString(), new { policycode = policycode }, CommandType.Text).ToList();
        }
        public List<ServiceType> GetProviderServices(int providerId)
        {
            return QueryExecutor.Query<ServiceType>(StoreProcedures.USP_GetTPAProviderServices.ToString(), new { @ProviderID  = providerId}, CommandType.StoredProcedure).ToList();
        }

    }
}
