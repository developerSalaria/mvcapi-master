using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA.Common.Core.Model
{
    public class ProviderExcelModel
    {
        public string ClaimNumber { get; set; }
        public string InsuredName { get; set; }

        public string PolicyCode { get; set; }
        public string Provider { get; set; }
        public string Visittype { get; set; }
        public string VisitDate { get; set; }
        public string PaymentInfo { get; set; }
        public string Status { get; set; }
        public string LastModified { get; set; }
        public string ProviderNotes { get; set; }
        public string AuditorNotes { get; set; }
        public string ServiceName { get; set; }
        public string ServiceType { get; set; }
        public string Servicesubtype { get; set; }
        public string Coshareamount { get; set; }
        public string Insured { get; set; }
        public string Price { get; set; }
        public string CoShareType { get; set; }
        public string CoShare { get; set; }
        public string ServiceStatus { get; set; }
        public string Symptoms { get; set; }
        public string InsuranceCompany { get; set; }

        public string InsuredCompany { get; set; }
        public string PolicyNumber { get; set; }
        public string SubPolicy { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentDate { get; set; }
        public string PaymentDetails { get; set; }
        public string PaymentReference { get; set; }

        public string PaymentLastModifiedBy { get; set; }

        public string PaymentLastModifiedDate { get; set; }

     
    }

    public class ExcelRequest
    {
        public List<ProviderExcelModel> dataModel { get; set; }
    }
}
