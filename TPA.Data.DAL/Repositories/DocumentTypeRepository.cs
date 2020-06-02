using TPA.Common.Core.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace TPA.Data.DAL.Repositories
{
    public class DocumentTypeRepository : BaseRepository
    {
        public List<DocumentType> Get()
        {
            return QueryExecutor.Query<DocumentType>(StoreProcedures.sp_DocumentType_Get.ToString(), null, CommandType.StoredProcedure).ToList();
        }

        public DocumentType GetById(int DocumentTypeId)
        {
            return QueryExecutor.Query<DocumentType>(StoreProcedures.sp_DocumentType_Get.ToString(), new { DocumentTypeId }, CommandType.StoredProcedure).ToList().FirstOrDefault();
        }

        public int DeleteById(int DocumentTypeId)
        {
            return QueryExecutor.Execute(StoreProcedures.sp_DocumentType_Delete.ToString(), new { DocumentTypeId }, CommandType.StoredProcedure);
        }

        public int Update(DocumentType obj)
        {
            return QueryExecutor.Execute(StoreProcedures.sp_DocumentType_Update.ToString(), new {
                obj.DocumentTypeId,
                obj.DocumentTypeA,
                obj.DocumentTypeE,
                obj.Code,
                obj.UserId,
                obj.CreatedDate,
                obj.ModifiedDate
            });
        }

        public int Insert(DocumentType obj)
        {
            return QueryExecutor.Execute(StoreProcedures.sp_DocumentType_Insert.ToString(), new
            {
                obj.DocumentTypeA,
                obj.DocumentTypeE,
                obj.Code,
                obj.UserId,
                obj.CreatedDate,
                obj.ModifiedDate
            });
        }
    }
}
