using TPA.Common.Core.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace TPA.Data.DAL.Repositories
{
    public class CustomerTypeRepository : BaseRepository
    {
        public List<CustomerType> Get()
        {
            return QueryExecutor.Query<CustomerType>(StoreProcedures.sp_CustomerType_Get.ToString(), null, CommandType.StoredProcedure).ToList();
        }

        public CustomerType GetById(int CustomerTypeId)
        {
            return QueryExecutor.Query<CustomerType>(StoreProcedures.sp_CustomerType_Get.ToString(), new { CustomerTypeId }, CommandType.StoredProcedure).ToList().FirstOrDefault();
        }

        public int DeleteById(int CustomerTypeId)
        {
            return QueryExecutor.Execute(StoreProcedures.sp_CustomerType_Delete.ToString(), new { CustomerTypeId }, CommandType.StoredProcedure);
        }

        public int Update(CustomerType obj)
        {
            return QueryExecutor.Execute(StoreProcedures.sp_CustomerType_Update.ToString(), new {
                obj.CustomerTypeId,
                obj.CustomerTypeNameA,
                obj.CustomerTypeNameE,
                obj.CustomerTypeCode,
                obj.UserId,
                obj.ModifiedDate,
            });
        }

        public int Insert(CustomerType obj)
        {
            return QueryExecutor.Execute(StoreProcedures.sp_CustomerType_Insert.ToString(), new {
                obj.CustomerTypeId,
                obj.CustomerTypeNameA,
                obj.CustomerTypeNameE,
                obj.CustomerTypeCode,
                obj.UserId,
                obj.CreatedDate
            });
        }
    }
}
