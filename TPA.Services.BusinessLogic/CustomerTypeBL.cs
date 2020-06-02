using TPA.Common.Core.Model;
using TPA.Data.DAL.Repositories;
using System.Collections.Generic;

namespace TPA.Services.BusinessLogic
{
    public class CustomerTypeBL
    {
        private CustomerTypeRepository _customerTypeRepo;
        public CustomerTypeBL()
        {
            _customerTypeRepo = new CustomerTypeRepository();
        }

        public List<CustomerType> Get()
        {
            return _customerTypeRepo.Get();
        }

        public CustomerType GetById(int customerTypeId)
        {
            return _customerTypeRepo.GetById(customerTypeId);
        }

        public int DeleteById(int customerTypeId)
        {
            return _customerTypeRepo.DeleteById(customerTypeId);
        }

        public int Insert(CustomerType obj)
        {
            return _customerTypeRepo.Insert(obj);
        }

        public int Update(CustomerType obj)
        {
            return _customerTypeRepo.Update(obj);
        }
    }
}
