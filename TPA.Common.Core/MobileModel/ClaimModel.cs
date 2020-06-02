using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA.Common.Core.MobileModel
{
	public class ClaimModel
	{
		public int ID { get; set; }
		public string PolicyCode { get; set; }
		public string Member { get; set; }
		public int ClaimTypeId { get; set; }
		public int ProviderId { get; set; }
		public int ServiceTypeId { get; set; }
		public decimal ClaimedAmount { get; set; }
		public string ClaimReference { get; set; }
		public DateTime ServiceDate { get; set; }
		public int CurrencyId { get; set; }
		public bool IsApproved { get; set; }
		public bool IsActive { get; set; }
		public DateTime CreatedDate { get; set; }

		//GetClaim
		public string ClaimType { get; set; }
		public string ProviderName { get; set; }
		public string ServiceName { get; set; }

		public int PaymentMethodId { get; set; }
		public bool IsSubmitted { get; set; }

	}
}
