using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA.Common.Core.Model;
using TPA.Data.DAL.Repositories;

namespace TPA.Services.BusinessLogic
{
    public class SymptomsBL
    {

        private SymptomsRepository _repo;
        public SymptomsBL()
        {
            _repo = new SymptomsRepository();
        }
        public List<Symptoms> Get()
        {
            return _repo.Get();
        }

        public List<Symptoms> Get(string symptom)
        {
            return _repo.Get(symptom);
        }
    }
}
