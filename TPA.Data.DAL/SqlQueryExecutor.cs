using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using Dapper;

namespace TPA.Data.DAL
{
    public class SqlQueryExecutor
    {
        public string ConnectionString { get; set; }

        public SqlQueryExecutor(string connectionString)
        {
            ConnectionString = connectionString;
        }

        internal object Query<T>(object gET_ALL_STATUS, object p, CommandType text)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Query<T>(string sql, object param = null, CommandType commandType = CommandType.StoredProcedure)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                else if (conn.State == ConnectionState.Broken || conn.State == ConnectionState.Connecting || conn.State == ConnectionState.Executing || conn.State == ConnectionState.Fetching)
                {
                    conn.Close();
                    conn.Open();
                }

                return conn.Query<T>(sql, param, commandType: commandType);
            }
        }

        public T QueryFirst<T>(string sql, object param = null, CommandType commandType = CommandType.StoredProcedure)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                else if (conn.State == ConnectionState.Broken || conn.State == ConnectionState.Connecting || conn.State == ConnectionState.Executing || conn.State == ConnectionState.Fetching)
                {
                    conn.Close();
                    conn.Open();
                }

                return conn.QueryFirstOrDefault<T>(sql, param, commandType: commandType);
            }
        }

        public int Execute(string sql, object param = null, CommandType commandType = CommandType.StoredProcedure)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                else if (conn.State == ConnectionState.Broken || conn.State == ConnectionState.Connecting || conn.State == ConnectionState.Executing || conn.State == ConnectionState.Fetching)
                {
                    conn.Close();
                    conn.Open();
                }

                return conn.Execute(sql, param, commandType: commandType);
            }
        }

        public int ExecuteWithParameter(string sql, DynamicParameters param = null, CommandType commandType = CommandType.StoredProcedure)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                else if (conn.State == ConnectionState.Broken || conn.State == ConnectionState.Connecting || conn.State == ConnectionState.Executing || conn.State == ConnectionState.Fetching)
                {
                    conn.Close();
                    conn.Open();
                }

                return conn.Execute(sql, param, commandType: commandType);
            }
        }

        public object ExecuteScalar(string sql, object param = null, CommandType commandType = CommandType.StoredProcedure)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                else if (conn.State == ConnectionState.Broken || conn.State == ConnectionState.Connecting || conn.State == ConnectionState.Executing || conn.State == ConnectionState.Fetching)
                {
                    conn.Close();
                    conn.Open();
                }

                return conn.ExecuteScalar(sql, param, commandType: commandType);
            }
        }

        public T ExecuteWithReturnValue<T>(string sql, string returnParameter, DynamicParameters param = null, CommandType commandType = CommandType.StoredProcedure)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                else if (conn.State == ConnectionState.Broken || conn.State == ConnectionState.Connecting || conn.State == ConnectionState.Executing || conn.State == ConnectionState.Fetching)
                {
                    conn.Close();
                    conn.Open();
                }

                conn.Execute(sql, param, commandType: commandType);
                return param.Get<T>(returnParameter);
            }
        }

        public IDataReader GetReader<T>(string sql, object param = null, CommandType commandType = CommandType.StoredProcedure)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                else if (conn.State == ConnectionState.Broken || conn.State == ConnectionState.Connecting || conn.State == ConnectionState.Executing || conn.State == ConnectionState.Fetching)
                {
                    conn.Close();
                    conn.Open();
                }

                return conn.ExecuteReader(sql, param, commandType: commandType);
            }
        }

        internal object GetDataTable(object p1, object p2, CommandType text)
        {
            throw new NotImplementedException();
        }

        public DataTable GetDataTable(string sql, object param = null, CommandType commandType = CommandType.StoredProcedure)
        {
            return Query<Object>(sql, param, commandType).ToList().ToDataTable();
        }

        public DataTable GetDataTableSelect(string sql, object param = null, CommandType commandType = CommandType.StoredProcedure)
        {
            return Query<Object>(sql, param, commandType).ToList().ToDataTableSelect();
        }

        public IEnumerable<T> QueryOleDb<T>(string sql, object param = null, CommandType commandType = CommandType.StoredProcedure)
        {
            using (var conn = new OleDbConnection(ConnectionString))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                else if (conn.State == ConnectionState.Broken || conn.State == ConnectionState.Connecting || conn.State == ConnectionState.Executing || conn.State == ConnectionState.Fetching)
                {
                    conn.Close();
                    conn.Open();
                }

                return conn.Query<T>(sql, param, commandType: commandType);
            }
        }

        public int ExecuteOleDb(string sql, object param = null, CommandType commandType = CommandType.StoredProcedure)
        {
            using (var conn = new OleDbConnection(ConnectionString))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                else if (conn.State == ConnectionState.Broken || conn.State == ConnectionState.Connecting || conn.State == ConnectionState.Executing || conn.State == ConnectionState.Fetching)
                {
                    conn.Close();
                    conn.Open();
                }

                return conn.Execute(sql, param, commandType: commandType);
            }
        }

        public DataTable GetDataTableOledb(string sql, object param = null, CommandType commandType = CommandType.StoredProcedure)
        {
            return QueryOleDb<Object>(sql, param, commandType).ToList().ToDataTable();
        }
    }
}
