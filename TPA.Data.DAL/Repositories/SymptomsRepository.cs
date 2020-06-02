using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA.Common.Core.Model;

namespace TPA.Data.DAL.Repositories
{
    public class SymptomsRepository : BaseRepository
    {
        public List<Symptoms> Get()
        {
            return QueryExecutor.Query<Symptoms>(SQLs.GET_ALL_SYMPTOMS.ToString(), null, CommandType.Text).ToList();
        }


        public List<Symptoms> Get(string symptom)
        {
            return QueryExecutor.Query<Symptoms>(SQLs.GET_SYMPTOMS, new { search = symptom }, CommandType.Text).ToList();
        }
    }
}
