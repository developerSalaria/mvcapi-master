using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA.Common.Core.Model;
using TPA.Data.DAL.Repositories;

namespace TPA.Services.BusinessLogic
{
    public class DoctorSpecialityBL
    {
        private DoctorSpecialityRepository _repo;
        public DoctorSpecialityBL()
        {
            _repo = new DoctorSpecialityRepository();
        }

        public List<DoctorSpeciality> Get()
        {
            return _repo.Get();
        }

        public DoctorSpeciality GetById(int id)
        {
            return _repo.GetById(id);
        }
    }
}
