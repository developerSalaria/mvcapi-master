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
    public class FileRepository : BaseRepository
    {
        public int SaveFile(FileData file)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("FileName", file.FileName);
            parameters.Add("Action_Type", 101);
            parameters.Add("Contents", file.Contents);
            parameters.Add("ContentType", file.ContentType);
            parameters.Add("@ID", dbType: DbType.Int32, direction: ParameterDirection.Output);
            return QueryExecutor.ExecuteWithReturnValue<int>(StoreProcedures.usp_SaveUpdateFile.ToString(), "ID", parameters, CommandType.StoredProcedure);
        }

        public FileData GetFile(int fileId)
        {
            return QueryExecutor.Query<FileData>(SQLs.GET_FILE, new { @ID = fileId }, CommandType.Text).FirstOrDefault();
        }
    }
}
