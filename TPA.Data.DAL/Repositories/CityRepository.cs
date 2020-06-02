using TPA.Common.Core.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace TPA.Data.DAL.Repositories
{
    public class CityRepository : BaseRepository
    {
        public List<City> Get()
        {
            return QueryExecutor.Query<City>(StoreProcedures.sp_City_Get.ToString(), null, CommandType.StoredProcedure).ToList();
        }

        public City GetById(int CityId)
        {
            return QueryExecutor.Query<City>(StoreProcedures.sp_City_Get.ToString(), new { CityId }, CommandType.StoredProcedure).ToList().FirstOrDefault();
        }

        public int DeleteById(int CityId)
        {
            return QueryExecutor.Execute(StoreProcedures.sp_City_Delete.ToString(), new { CityId }, CommandType.StoredProcedure);
        }

        public int Update(City obj)
        {
            return QueryExecutor.Execute(StoreProcedures.sp_City_Update.ToString(), new { obj.CityCode,obj.CityId,obj.CityNameA,obj.CityNameE,obj.CountryId,obj.CountryName,obj.FavouriteCity,obj.ModifiedDate,obj.UserId });
        }

        public int Insert(City obj)
        {
            return QueryExecutor.Execute(StoreProcedures.sp_City_Insert.ToString(), new { obj.CityCode, obj.CityNameA, obj.CityNameE, obj.CountryId, obj.CountryName, obj.FavouriteCity, obj.ModifiedDate, obj.UserId });
        }
    }
}
