using TPA.Common.Core.Model;
using TPA.Services.BusinessLogic.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TPA.Services.ClientApi.Controllers
{
    public class CustomerMangementController : ApiController
    {
        private EmployeeBL _empRepo;
        public CustomerMangementController()
        {
            _empRepo = new EmployeeBL();
        }

        //[Authorize]
      
        public List<Employee> GetList()
        {
            return _empRepo.Get();
        }
    }
}
