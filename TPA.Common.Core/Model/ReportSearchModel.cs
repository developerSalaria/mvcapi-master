using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA.Common.Core.Model
{
    public class ReportSearchModel : BaseModel
    {
        public string SearchProvider { get; set; }
        public string SearchContactractor { get; set; }
        public string SearchCompanyName { get; set; }
        public string SearchEmployeeName { get; set; }
        public DateTime? SearchFromDate { get; set; }
        public DateTime? SearchToDate { get; set; }
        public string SearchEmployeeInsuranceId { get; set; }
        public int? SearchStatusId { get; set; }
        public int? SearchVisitTypeId { get; set; }
        public int? SearchClaimId { get; set; }
        public int? searchPaymentStatusId { get; set; }
    }
    public class ReportLossRatioSearchModel
    {
        public string SearchPolicy { get; set; }
        public string SearchCompanyName { get; set; }
    }

    //Main Policy Id Main Policy Number  Policy Amount   Total Insured   Ratio Company

    public class LossRatioReportModel
    {

        public string MainPolicyId { get; set; }
        public string MainPolicyNumber { get; set; }
        public string PolicyAmount { get; set; }
        public string TotalInsured { get; set; }
        public string Ratio { get; set; }
        public string Company { get; set; }

    }


    public class PaymentReportModel
    {

        public string SearchProvider { get; set; }
        public string ClaimNumber { get; set; }
        public string InsuredName { get; set; }
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
        public decimal Coshareamount { get; set; }
        public decimal Insured { get; set; }

        public decimal Price { get; set; }
        public string CoShareType { get; set; }
        public string CoShare { get; set; }
        public string ServiceStatus { get; set; }
        public string Symptoms { get; set; }
        public string InsuranceCompany { get; set; }
        public string PolicyNumber { get; set; }
        public string SubPolicy { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentDate { get; set; }
        public string PaymentDetails { get; set; }
        public string PaymentLastmodifiedby { get; set; }
        public string PaymentLastmodifiedDate { get; set; }
        public string PaymentReference { get; set; }
    }

    public class ProviderReportModel
    {

        public string SearchProvider { get; set; }
        public string ClaimNumber { get; set; }
        public string InsuredName { get; set; }
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
        public decimal Coshareamount { get; set; }
        public decimal Insured { get; set; }
        public decimal price { get; set; }
        public string CoShareType { get; set; }
        public string CoShare { get; set; }
        public string ServiceStatus { get; set; }
        public string Symptoms { get; set; }
        public string InsuranceCompany { get; set; }
        public string PolicyNumber { get; set; }
        public string SubPolicy { get; set; }
        public string PaymentStatus { get; set; }
        public string DOB { get; set; }
        public string VisitorName { get; set; }
        public string PaymentLastmodifiedby { get; set; }
        
    }
}
