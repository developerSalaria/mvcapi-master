using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA.Common.Core.Model
{
    public class TPAClaim : BaseModel
    {
        public int ID { get; set; }
        public string ClaimNo { get; set; }
        public string InsureName { get; set; }
        public int PlanID { get; set; }
        public int PolicyID { get; set; }
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public int PolicyHolderID { get; set; }
        public int TerritoryID { get; set; }
        public int ProviderID { get; set; }
        public int VisitTypeID { get; set; }
        public DateTime VisitDate { get; set; }
        public string VisitDatestr { get; set; }
        public int DoctorSpecialityID { get; set; }
        public string ProviderNotes { get; set; }
        public string AuditorNotes { get; set; }
        public int StatusID { get; set; }
        public DateTime EntryDate { get; set; }
        public string ConfinementType { get; set; }
        public DateTime AdmissionDate { get; set; }
        public DateTime ExitDate { get; set; }
        public string InvoiceNumber { get; set; }
        public string AdditionalInfo { get; set; }
        public string PaymentBy { get; set; }
        public string PaymentType { get; set; }
        public string ClaimType { get; set; }
        public decimal TotalReservedAmount { get; set; }
        public decimal TotalAmountToBePaid { get; set; }

        //
        [Required]
        public string PolicyCode { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }
        public string EmployeeType { get; set; }
        public string PersonalTelNo { get; set; }

        public int? AttachmentId { get; set; }

    }

}
