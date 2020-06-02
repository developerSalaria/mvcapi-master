using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA.Common.Core.MobileModel
{
    public class UserModel
    {
        public string UserIdentity { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string DOB { get; set; }
        public string Name { get; set; }
        public string UserRoles { get; set; }

        public string EmployeeCode { get; set; }

        public string PolicyCode { get; set; }

    }
}
