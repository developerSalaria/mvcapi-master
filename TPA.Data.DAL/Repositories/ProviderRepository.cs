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
    public class ProviderRepository : BaseRepository
    {
        public List<Provider> Get()
        {
            return QueryExecutor.Query<Provider>(SQLs.GET_ALL_PROVIDERS, null, CommandType.Text).ToList();
        }

        public Provider GetById(int providerId)
        {
            return QueryExecutor.Query<Provider>(SQLs.GET_PROVIDER_BY_ID, new { ProviderID = providerId }, CommandType.Text).FirstOrDefault();
        }

        public int AddProvider(Provider provider)
        {
            var obj = new
            {
                Action_Type = 101, // TODO: not sure if this is correct
                Name = provider.Name,
                Code = provider.Code,
                Address = provider.Address,
                CountryID = provider.CountryID,
                CurrencyID = provider.CountryID,
                TelephoneNo = provider.TelephoneNo,
                Fax = provider.Fax,
                POBoxNo = provider.POBoxNo,
                Email = provider.Email,
                ProfilePicture = provider.ProfilePicture,
                ProviderTypeID = provider.ProviderTypeID,
                InNetwork = provider.InNetwork,
                Within_Outside_Network = provider.Within_Outside_Network,
                CreatedOn = DateTime.Now, // TODO: need to pass correct value
                CreatedBy = provider.CreatedBy,
                UpdatedOn = DateTime.Now, // TODO: need to pass correct value
                UpdatedBy = provider.UpdatedBy,
            };
            DynamicParameters dynamicParameters = new DynamicParameters(obj);
            dynamicParameters.Add("@ID", dbType: DbType.Int32, direction: ParameterDirection.Output);
            return QueryExecutor.ExecuteWithReturnValue<int>(StoreProcedures.usp_GetSaveUpdateTPAProvider.ToString(), "ID", dynamicParameters, CommandType.StoredProcedure);
        }
    }
}
