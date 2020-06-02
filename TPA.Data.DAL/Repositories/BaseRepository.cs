using TPA.Data.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA.Data.DAL
{
   public class BaseRepository
    {
        private string _connectionString;
        private SqlQueryExecutor _queryExecutor;

        public SqlQueryExecutor QueryExecutor { get { return _queryExecutor; } }
        public string ConnectionString
        {
            get
            {
                return _connectionString;
            }
            set
            {
                _connectionString = ConfigurationManager.ConnectionStrings[value].ToString();
                _queryExecutor = new SqlQueryExecutor(_connectionString);
            }
        }

        public BaseRepository()
        {
            ConnectionString = DbConnectionString.AccountingSystemDB;
        }

        public int TotalCountOfTable(string tableName)
        {
            var Result = QueryExecutor.GetDataTable(StoreProcedures.sp_TotalCount_ByTable.ToString(), new { tableName }, CommandType.StoredProcedure);
            int TotalCount = Convert.ToInt32(Result.Rows[0][0]);
            return TotalCount;
        }
    }
}
