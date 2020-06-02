using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPA.Common.Core.Model
{
    public class SubPolicy : BaseModel
    {
        public string PolicyNo { get; set; }
        public string Contracter { get; set; }
        public string CustomerCompany { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? LastModified { get; set; }
        public int? SubPolicyNo { get; set; }
        public string EmployeeType { get; set; }
        public string EmployeeRelation { get; set; }

    }
}
