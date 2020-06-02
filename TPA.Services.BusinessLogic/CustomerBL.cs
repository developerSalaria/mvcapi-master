using TPA.Common.Core.Model;
using TPA.Data.DAL.Repositories;
using System.Collections.Generic;

namespace TPA.Services.BusinessLogic
{
    public class CustomerBL
    {
        private CustomerRepository _customerRepo;
        private CustomerDocumentRepository _customerDocumentRepo;
        public CustomerBL()
        {
            _customerRepo = new CustomerRepository();
            _customerDocumentRepo = new CustomerDocumentRepository();
        }

        public List<Customer> Get()
        {
            return _customerRepo.Get();
        }

        public CustomerViewModel CustomerDataTable(Customer c)
        {
            return _customerRepo.CustomerDataTable(c);
        }

        public Customer GetById(int customerId)
        {
            var result = _customerRepo.GetById(customerId);
            if (result.GenderId==1)
            {
                result.IsMale = true;
            }

            result.CustomerDocument = _customerDocumentRepo.GetByCustomerId(customerId);

            if (result.CustomerDocument== null)
            {
                result.CustomerDocument = new CustomerDocument();
            }

            return result;
        }

        public int DeleteById(int customerId)
        {
            return _customerRepo.DeleteById(customerId);
        }

        public int Insert(Customer obj)
        {
            return _customerRepo.Insert(obj);
        }

        public int Update(Customer obj)
        {
            return _customerRepo.Update(obj);
        }
    }
}
