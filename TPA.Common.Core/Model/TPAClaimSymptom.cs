using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA.Common.Core.Model
{
    public class TPAClaimSymptom : BaseModel
    {
        public int ID { get; set; }
        public int ClaimID { get; set; }
        public int SymptomsID { get; set; }
    }
}
