using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA.Common.Core.Model
{
    public class Provider : BaseModel
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int CountryID { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public int CurrencyID { get; set; }
        public string TelephoneNo { get; set; }
        public string ContractNumber { get; set; }
        public DateTime? ContractStartDate { get; set; }
        public DateTime? ContractExpiryDate { get; set; }
        public string Fax { get; set; }
        public string PaymentDetails { get; set; }
        public bool IsStatusActive { get; set; }
        public string POBoxNo { get; set; }
        public string Email { get; set; }
        public string ProfilePicture { get; set; }
        public int ProviderTypeID { get; set; }
        public bool InNetwork { get; set; }
        public string Within_Outside_Network { get; set; }
    }
}
