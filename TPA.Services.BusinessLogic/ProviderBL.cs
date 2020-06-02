using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA.Common.Core.Model;
using TPA.Data.DAL.Repositories;

namespace TPA.Services.BusinessLogic
{
    public class ProviderBL
    {
        private ProviderRepository _providerRepo;
        public ProviderBL()
        {
            _providerRepo = new ProviderRepository();
        }

        public List<Provider> Get()
        {
            return _providerRepo.Get();
        }

        public Provider GetById(int providerId)
        {
            return _providerRepo.GetById(providerId);
        }

        public int AddProvider(Provider provider)
        {
            return _providerRepo.AddProvider(provider);
        }
    }
}
