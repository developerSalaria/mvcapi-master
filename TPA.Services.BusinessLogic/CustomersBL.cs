using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA.Common.Core.Model;
using TPA.Data.DAL.Repositories;

namespace TPA.Services.BusinessLogic
{
    public class CustomersBL
    {
        private CustomersRepository _customersRepository;
        public CustomersBL()
        {
            _customersRepository = new CustomersRepository();
        }

        public List<Policy> GetPolicies()
        {
            return _customersRepository.GetPolicies();
        }

        public List<CustomerInsured> GetCustomersInsured()
        {
            return _customersRepository.GetCustomersInsured();
        }

        public List<SubPolicy> GetSubPoliciesByPolicyNo(string policyNo)
        {
            return _customersRepository.GetSubPoliciesByPolicyNo(policyNo);
        }
        public Policy GetPolicyByPolicyNo(string policyNo)
        {
            return _customersRepository.GetPolicyByPolicyNo(policyNo);
        }

        public int UpdatePolicy(Policy policy)
        {
            return _customersRepository.UpdatePolicy(policy);
        }
    }
}
