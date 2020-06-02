using TPA.Common.Core.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace TPA.Data.DAL.Repositories
{
    public class CountryRepository : BaseRepository
    {
        public List<Country> Get()
        {
            return QueryExecutor.Query<Country>(SQLs.sp_Country_Get.ToString(), null, CommandType.Text).ToList();
        }

        public Country GetById(int CountryId)
        {
            return QueryExecutor.Query<Country>(StoreProcedures.sp_Country_Get.ToString(), new { CountryId }, CommandType.StoredProcedure).ToList().FirstOrDefault();
        }

        public int DeleteById(int CountryId)
        {
            return QueryExecutor.Execute(StoreProcedures.sp_Country_Delete.ToString(), new { CountryId }, CommandType.StoredProcedure);
        }

        public int Update(Country obj)
        {
            return QueryExecutor.Execute(StoreProcedures.sp_Country_Update.ToString(), new {
            });
        }

        public int Insert(Country obj)
        {
            return QueryExecutor.Execute(StoreProcedures.sp_Country_Insert.ToString(), new {
            });
        }
    }
}
