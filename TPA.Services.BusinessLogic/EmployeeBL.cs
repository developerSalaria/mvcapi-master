using TPA.Common.Core.Model;
using TPA.Data.DAL.Repositories;
using System.Collections.Generic;

namespace TPA.Services.BusinessLogic.Classes
{
    public class EmployeeBL
    {
        private EmployeeRepository _employeeRepo;
        public EmployeeBL()
        {
            _employeeRepo = new EmployeeRepository();
        }

        public List<Employee> Get()
        {
            return _employeeRepo.Get();
        }
    }
}
