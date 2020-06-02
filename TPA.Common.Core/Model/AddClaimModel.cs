using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TPA.Common.Core.Model
{
    public class AddClaimModel
    {
        public TPAClaim Claim { get; set; }

        public int[] Symptoms { get; set; }

        public ClaimServiceType[] Services { get; set; }

        [JsonIgnore]
        public HttpPostedFileBase PostedFile { get; set; }
    }

    public class ClaimServiceType
    {
        public int ServiceTypeId { get; set; }
        public decimal ClaimAmount { get; set; }
    }
}
