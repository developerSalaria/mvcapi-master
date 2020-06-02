using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA.Common.Core.Model;

namespace TPA.Data.DAL.Repositories
{
    public class DoctorSpecialityRepository : BaseRepository
    {
        public List<DoctorSpeciality> Get()
        {
            return QueryExecutor.Query<DoctorSpeciality>(SQLs.GET_ALL_DOCTOR_SPECIALITIES, null, CommandType.Text).ToList();
        }

        public DoctorSpeciality GetById(int id)
        {
            return QueryExecutor.Query<DoctorSpeciality>(SQLs.GET_DOCTOR_SPECIALITIES_BY_ID, new { ID = id}, CommandType.Text).FirstOrDefault();
        }
    }
}
