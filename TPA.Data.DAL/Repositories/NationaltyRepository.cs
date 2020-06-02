using TPA.Common.Core.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace TPA.Data.DAL.Repositories
{
    public class NationaltyRepository : BaseRepository
    {
        public List<Nationalty> Get()
        {
            return QueryExecutor.Query<Nationalty>(StoreProcedures.sp_Nationalty_Get.ToString(), null, CommandType.StoredProcedure).ToList();
        }

        public Nationalty GetById(int NationaltyId)
        {
            return QueryExecutor.Query<Nationalty>(StoreProcedures.sp_Nationalty_Get.ToString(), new { NationaltyId }, CommandType.StoredProcedure).ToList().FirstOrDefault();
        }

        public int DeleteById(int NationaltyId)
        {
            return QueryExecutor.Execute(StoreProcedures.sp_Nationalty_Delete.ToString(), new { NationaltyId }, CommandType.StoredProcedure);
        }

        public int Update(Nationalty obj)
        {
            return QueryExecutor.Execute(StoreProcedures.sp_Nationalty_Update.ToString(), new {
                obj.NationalityId,
                obj.NationalityNameA,
                obj.NationalityNameE,
                obj.NationalityCode,
                obj.FavouriteNationality,
                obj.UserId,
                obj.ModifiedDate
            });
        }

        public int Insert(Nationalty obj)
        {
            return QueryExecutor.Execute(StoreProcedures.sp_Nationalty_Insert.ToString(), new {
                obj.NationalityId,
                obj.NationalityNameA,
                obj.NationalityNameE,
                obj.NationalityCode,
                obj.FavouriteNationality,
                obj.UserId,
                obj.CreatedDate,
            });
        }
    }
}
