using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA.Common.Core.Model
{
    public class InsurancePolicy : BaseModel
    {
        public int ID { get; set; }
        public string PolicyCode { get; set; }
        public string PolicyHolderType { get; set; }
        public int PolicyHolderID { get; set; }
        public int GroupPlanID { get; set; }
        public int PlanNameID { get; set; }
        public int PlanID { get; set; }
        public string Category { get; set; }
        public DateTime InceptionDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Note { get; set; }
        public int StatusID { get; set; }
    }
}
