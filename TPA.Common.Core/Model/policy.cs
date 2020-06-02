using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPA.Common.Core.Model
{
    public class Policy : BaseModel
    {
        public int Id { get; set; }
        public string PolicyNo { get; set; }
        public string Contractor { get; set; }
        public decimal? PolicyAmount { get; set; }
        public string CustomerCompany { get; set; }
        public string TermsAndConditions { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
