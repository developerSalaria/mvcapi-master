using TPA.Common.Core.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace TPA.Data.DAL.Repositories
{
    public class CustomerDocumentRepository : BaseRepository
    {
        public List<CustomerDocument> Get()
        {
            return QueryExecutor.Query<CustomerDocument>(StoreProcedures.sp_CustomerDocument_Get.ToString(), null, CommandType.StoredProcedure).ToList();
        }

        public CustomerDocument GetById(int CustomerDocumentId)
        {
            return QueryExecutor.Query<CustomerDocument>(StoreProcedures.sp_CustomerDocument_Get.ToString(), new { CustomerDocumentId }, CommandType.StoredProcedure).ToList().FirstOrDefault();
        }

        public CustomerDocument GetByCustomerId(int customerId)
        {
            return QueryExecutor.Query<CustomerDocument>(StoreProcedures.sp_CustomerDocument_GetByCustomerId.ToString(), new { customerId }, CommandType.StoredProcedure).ToList().FirstOrDefault();
        }


        public int DeleteById(int CustomerDocumentId)
        {
            return QueryExecutor.Execute(StoreProcedures.sp_CustomerDocument_Delete.ToString(), new { CustomerDocumentId }, CommandType.StoredProcedure);
        }

        public int Update(CustomerDocument obj)
        {
            return QueryExecutor.Execute(StoreProcedures.sp_CustomerDocument_Update.ToString(), new {
                obj.DocumentId,
                obj.DocumentTypeId,
                obj.DocumentNumber,
                obj.DocumentIssueBy,
                obj.DocumentIssueDate,
                obj.DocumentExpiryDate,
                obj.CustomerId
            });
        }

        public int Insert(CustomerDocument obj)
        {
            return QueryExecutor.Execute(StoreProcedures.sp_CustomerDocument_Insert.ToString(), new {
                obj.DocumentTypeId,
                obj.CustomerId,
                obj.DocumentNumber,
                obj.DocumentIssueBy,
                obj.DocumentIssueDate,
                obj.DocumentExpiryDate,
            });
        }
    }
}
