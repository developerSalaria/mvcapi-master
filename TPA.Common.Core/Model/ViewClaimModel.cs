using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA.Common.Core.Model
{
    public class ViewClaimModel
    {
        public TPAClaim Claim { get; set; }

        public List<ServiceType> Services { get; set; }

        public List<Symptoms> Symptoms { get; set; }
    }
}
