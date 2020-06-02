using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA.Common.Core.Model
{
    public class TPAClaimServiceBalance
    {
        public int ServicesTypeID { get; set; }
        public decimal ServiceAmount { get; set; }
        public decimal ClaimedAmount { get; set; }
        public decimal Balance { get; set; }
    }

    public class TPAServices
    {
        public int ID { get; set; }
        public decimal EName { get; set; }
        public decimal ServiceAmount { get; set; }
        public decimal CoShareAmount { get; set; }
        public decimal CoSharePercentage { get; set; }
        public decimal InsuredAmount { get; set; }
    }
}
