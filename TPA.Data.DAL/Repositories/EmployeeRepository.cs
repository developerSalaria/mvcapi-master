using TPA.Common.Core.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace TPA.Data.DAL.Repositories
{
    public class EmployeeRepository : BaseRepository
    {
        public List<Employee> Get()
        {
            return QueryExecutor.Query<Employee>(StoreProcedures.sp_GetEmp.ToString(), null, CommandType.StoredProcedure).ToList();
        }
    }
}
