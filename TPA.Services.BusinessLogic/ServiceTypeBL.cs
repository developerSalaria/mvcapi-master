using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA.Common.Core.Model;
using TPA.Data.DAL.Repositories;

namespace TPA.Services.BusinessLogic
{
    public class ServiceTypeBL
    {
        private ServiceTypeRepository _repo;
        public ServiceTypeBL()
        {
            _repo = new ServiceTypeRepository();
        }
        public List<ServiceType> Get(string policycode)
        {
            return _repo.Get(policycode);
        }

        public List<ServiceType> GetProviderServices(int providerId)
        {
            return _repo.GetProviderServices(providerId);
        }
    }
}
