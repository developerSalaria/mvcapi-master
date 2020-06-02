using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA.Common.Core.Model;
using TPA.Data.DAL.Repositories;

namespace TPA.Services.BusinessLogic
{
    public class VisitTypeBL
    {
        private VisitTypeRepository _visitTypeRepo;
        public VisitTypeBL()
        {
            _visitTypeRepo = new VisitTypeRepository();
        }

        public List<VisitType> Get()
        {
            return _visitTypeRepo.Get();
        }

        public VisitType GetById(int id)
        {
            return _visitTypeRepo.GetById(id);
        }
    }
}
