using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPA.Models.Claims
{
    public class ClaimsModel
    {
        public string claimID { get; set; }
        public string provider { get; set; }
        public string insuranceNo { get; set; }
        public string visitType { get; set; }
        public string visitDate { get; set; }
        public string visitorName { get; set; }
        public string status { get; set; }
        public string LastModifiedDate { get; set; }
        public string CreatedDate { get; set; }
        
    }
}