using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA.Common.Core.MobileModel
{
	public class PaymentModel
	{
		public int ID { get; set; }
		public int CountryId { get; set; }
		public string IBAN { get; set; }
		public string Swift_BIC { get; set; }
		public string AccountNo { get; set; }
		public string AccountName { get; set; }
		public int CurrencyId { get; set; }
		public string BankName { get; set; }
		public string BankAddress { get; set; }
		public string Branch { get; set; }
		public string City { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public string EmployeeId { get; set; }
		public bool IsActive { get; set; }
		public DateTime CreatedDate { get; set; }
		public string EmployeeCode { get; set; }
	}
}
