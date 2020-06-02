using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA.Common.Core.Model;

namespace TPA.Data.DAL.Repositories
{
    public class VisitTypeRepository : BaseRepository
    {
        public List<VisitType> Get()
        {
            return QueryExecutor.Query<VisitType>(SQLs.GET_ALL_VISIT_TYPES, null, CommandType.Text).ToList();
        }

        public VisitType GetById(int id)
        {
            return QueryExecutor.Query<VisitType>(SQLs.GET_VISIT_TYPE_BY_ID, new { ID = id }, CommandType.Text).FirstOrDefault();
        }
    }
}
