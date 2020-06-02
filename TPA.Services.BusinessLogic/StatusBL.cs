using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA.Common.Core.Model;
using TPA.Data.DAL.Repositories;

namespace TPA.Services.BusinessLogic
{
    public class StatusBL
    {
        private StatusRepository _repo;
        public StatusBL()
        {
            _repo = new StatusRepository();
        }

        public List<Status> Get()
        {
            return _repo.Get();
        }

        public Status GetById(int id)
        {
            return _repo.GetById(id);
        }
    }
}
