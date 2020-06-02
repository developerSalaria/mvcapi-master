using TPA.Common.Core.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace TPA.Data.DAL.Repositories
{
    public class CurrencyRepository : BaseRepository
    {
        public List<Currency> Get()
        {
            return QueryExecutor.Query<Currency>(StoreProcedures.sp_Currency_Get.ToString(), null, CommandType.StoredProcedure).ToList();
        }

        public Currency GetById(int CurrencyId)
        {
            return QueryExecutor.Query<Currency>(StoreProcedures.sp_Currency_Get.ToString(), new { CurrencyId }, CommandType.StoredProcedure).ToList().FirstOrDefault();
        }

        public int DeleteById(int CurrencyId)
        {
            return QueryExecutor.Execute(StoreProcedures.sp_Currency_Delete.ToString(), new { CurrencyId }, CommandType.StoredProcedure);
        }

        public int Update(Currency obj)
        {
            return QueryExecutor.Execute(StoreProcedures.sp_Currency_Update.ToString(), new {
                obj.CurrencyId,
                obj.CurrencyNameA,
                obj.CurrencyNameE,
                obj.CurrencyCode,
                obj.FavouriteCurrency,
                obj.UserId,
                obj.ModifiedDate,
            });
        }

        public int Insert(Currency obj)
        {
            return QueryExecutor.Execute(StoreProcedures.sp_Currency_Insert.ToString(), new {
                obj.CurrencyId,
                obj.CurrencyNameA,
                obj.CurrencyNameE,
                obj.CurrencyCode,
                obj.FavouriteCurrency,
                obj.UserId,
                obj.CreatedDate
            });
        }
    }
}
