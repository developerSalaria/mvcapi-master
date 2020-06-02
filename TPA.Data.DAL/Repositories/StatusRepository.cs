using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA.Common.Core.Model;

namespace TPA.Data.DAL.Repositories
{
    public class StatusRepository : BaseRepository
    {
        public List<Status> Get()
        {
            return QueryExecutor.Query<Status>(SQLs.GET_ALL_STATUS, null, CommandType.Text).ToList();
        }

        public Status GetById(int id)
        {
            return QueryExecutor.Query<Status>(SQLs.GET_STATUS_BY_ID, new { ID = id }, CommandType.Text).FirstOrDefault();
        }
    }
}
