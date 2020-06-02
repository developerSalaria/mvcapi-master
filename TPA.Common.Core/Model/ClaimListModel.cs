using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPA.Common.Core.Model
{
    public class ClaimListModel : BaseModel
    {
        public int? ClaimID { get; set; }
        public string ClaimNo { get; set; }
        public string  Provider { get; set; }
        public string InsuranceNo { get; set; }
        public string VisitType { get; set; }
        public DateTime? VisitDate { get; set; }
        public string VisitDateStr { get; set; }
        public string VisiterName { get; set; }
        public string Status { get; set; }
        public string LastModified { get; set; }
        public string LastModifiedBy { get; set; }
        public string CreatedAt { get; set; }
    }
}
