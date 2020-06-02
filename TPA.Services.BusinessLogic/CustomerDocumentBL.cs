using TPA.Common.Core.Model;
using TPA.Data.DAL.Repositories;
using System.Collections.Generic;

namespace TPA.Services.BusinessLogic
{
    public class CustomerDocumentBL
    {
        private CustomerDocumentRepository _customerDocumentRepo;
        public CustomerDocumentBL()
        {
            _customerDocumentRepo = new CustomerDocumentRepository();
        }

        public List<CustomerDocument> Get()
        {
            return _customerDocumentRepo.Get();
        }

        public CustomerDocument GetById(int customerDocumentId)
        {
            return _customerDocumentRepo.GetById(customerDocumentId);
        }
        public CustomerDocument GetByCustomerId(int customerId)
        {
            return _customerDocumentRepo.GetByCustomerId(customerId);
        }
        public int DeleteById(int customerDocumentId)
        {
            return _customerDocumentRepo.DeleteById(customerDocumentId);
        }

        public int Insert(CustomerDocument obj)
        {
            return _customerDocumentRepo.Insert(obj);
        }

        public int Update(CustomerDocument obj)
        {
            return _customerDocumentRepo.Update(obj);
        }
    }
}
