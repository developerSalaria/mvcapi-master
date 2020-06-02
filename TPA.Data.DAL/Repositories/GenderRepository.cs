using TPA.Common.Core.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace TPA.Data.DAL.Repositories
{
    public class GenderRepository : BaseRepository
    {
        public List<Gender> Get()
        {
            return QueryExecutor.Query<Gender>(StoreProcedures.sp_Gender_Get.ToString(), null, CommandType.StoredProcedure).ToList();
        }

        public Gender GetById(int GenderId)
        {
            return QueryExecutor.Query<Gender>(StoreProcedures.sp_Gender_Get.ToString(), new { GenderId }, CommandType.StoredProcedure).ToList().FirstOrDefault();
        }

        public int DeleteById(int GenderId)
        {
            return QueryExecutor.Execute(StoreProcedures.sp_Gender_Delete.ToString(), new { GenderId }, CommandType.StoredProcedure);
        }

        public int Update(Gender obj)
        {
            return QueryExecutor.Execute(StoreProcedures.sp_Gender_Update.ToString(), new {
                obj.GenderId,
                obj.GenderNameA,
                obj.GenderNameE
            });
        }

        public int Insert(Gender obj)
        {
            return QueryExecutor.Execute(StoreProcedures.sp_Gender_Insert.ToString(), new {
                obj.GenderNameA,
                obj.GenderNameE
            });
        }
    }
}
