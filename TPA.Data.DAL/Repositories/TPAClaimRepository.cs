using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA.Common.Core.Model;

namespace TPA.Data.DAL.Repositories
{
    public class TPAClaimRepository : BaseRepository
    {
        public List<TPAClaim> GetByPolicyCode(string PolicyCode)
        {
            return QueryExecutor.Query<TPAClaim>(StoreProcedures.USP_GETTPAPolicyCodeDetails.ToString(), new { Policycode = PolicyCode }, CommandType.StoredProcedure).ToList();
        }
        
        public List<TPAClaimServiceBalance> GetServiceBalanceByPolicyCode(string PolicyCode)
        {
            return QueryExecutor.Query<TPAClaimServiceBalance>(StoreProcedures.USP_GETTPAClaimServiceBalance.ToString(), new { Policycode = PolicyCode }, CommandType.StoredProcedure).ToList();
        }
        public TPAClaim GetById(string claimId)
        {
            return QueryExecutor.Query<TPAClaim>(StoreProcedures.USP_GetTPAClaimDetail.ToString(), new { ClaimID = claimId }, CommandType.StoredProcedure).FirstOrDefault();
        }

        public int AddClaim(TPAClaim claim)
        {
            var obj = new
            {
                Action_Type = 101, // TODO: not sure if this is correct
                //ID = claim.ID,
                ClaimNo = claim.ClaimNo,
                PlanID = claim.PlanID,
                PolicyCode = claim.PolicyCode,
                CompanyID = claim.CompanyID,
                CompanyName = claim.CompanyName,
                PolicyHolderID = claim.PolicyHolderID,
                TerritoryID = claim.TerritoryID,
                ProviderID = claim.ProviderID,
                VisitTypeID = claim.VisitTypeID,
                VisitDate = DateTime.Now, // TODO: need to pass correct value
                DoctorSpecialityID = claim.DoctorSpecialityID,
                ProviderNotes = claim.ProviderNotes,
                AuditorNotes = claim.AuditorNotes,
                StatusID = claim.StatusID,
                CreatedOn = DateTime.Now, // TODO: need to pass correct value
                CreatedBy = claim.CreatedBy,
                UpdatedOn = DateTime.Now, // TODO: need to pass correct value
                UpdatedBy = claim.UpdatedBy,
                EntryDate = DateTime.Now, // TODO: need to pass correct value
                ConfinementType = claim.ConfinementType,
                AdmissionDate = DateTime.Now, // TODO: need to pass correct value
                ExitDate = DateTime.Now, // TODO: need to pass correct value
                InvoiceNumber = claim.InvoiceNumber,
                AdditionalInfo = claim.AdditionalInfo,
                PaymentBy = claim.PaymentBy,
                PaymentType = claim.PaymentType,
                ClaimType = claim.ClaimType,
                TotalReservedAmount = claim.TotalReservedAmount,
                TotalAmountToBePaid = claim.TotalAmountToBePaid,
                AttachmentId = claim.AttachmentId
            };
            DynamicParameters dynamicParameters = new DynamicParameters(obj);
            dynamicParameters.Add("@ID", dbType: DbType.Int32, direction: ParameterDirection.Output);
            return QueryExecutor.ExecuteWithReturnValue<int>(StoreProcedures.usp_SaveUpdateClaim.ToString(), "ID", dynamicParameters, CommandType.StoredProcedure);
        }

        public void AddClaimServices(int claimId, ClaimServiceType[] serviceIds)
        {
            if (serviceIds?.Length > 0)
            {
                DataTable table = new DataTable();
                table.Columns.Add("ClaimID", typeof(int));
                table.Columns.Add("ServicesTypeID", typeof(int));
                table.Columns.Add("ClaimAmount", typeof(decimal));

                foreach (var id in serviceIds)
                {
                    DataRow dataRow = table.NewRow();
                    dataRow["ClaimID"] = claimId;
                    dataRow["ServicesTypeID"] = id.ServiceTypeId;
                    dataRow["ClaimAmount"] = id.ClaimAmount;
                    table.Rows.Add(dataRow);
                }

                QueryExecutor.Execute(StoreProcedures.usp_InsertUpdateTPAClaimServicesType.ToString(), new { tblTPAClaimServicesTypeTableType = table }, CommandType.StoredProcedure);
            }
        }

        public void AddClaimSymptoms(int claimId, int[] symptomIds)
        {
            if (symptomIds?.Length > 0)
            {
                DataTable table = new DataTable();
                table.Columns.Add("ClaimID", typeof(int));
                table.Columns.Add("SymptomsId", typeof(int));
                foreach (var id in symptomIds)
                {
                    DataRow dataRow = table.NewRow();
                    dataRow["ClaimID"] = claimId;
                    dataRow["SymptomsId"] = id;
                    table.Rows.Add(dataRow);
                }
             
        QueryExecutor.Execute(StoreProcedures.usp_InsertUpdateTPAClaimSymptoms.ToString(), new { tblTPAClaimSymptomsTableType = table }, CommandType.StoredProcedure);
            }
        }

        public int AddClaim(TPAClaim claim, ClaimServiceType[] servicesIds, int[] symptomsIds)
        {
            int claimId = AddClaim(claim);
            AddClaimServices(claimId, servicesIds);
            AddClaimSymptoms(claimId, symptomsIds);
            return claimId;
        }

        public List<ClaimListModel> GetAllClaims(ReportSearchModel reportSearchModel)
        {
            var obj = new
            {
                SearchProvider = reportSearchModel.SearchProvider,
                SearchContactractor = reportSearchModel.SearchContactractor,
                SearchEmployeeName = reportSearchModel.SearchEmployeeName,
                SearchFromDate = reportSearchModel.SearchFromDate,
                SearchToDate = reportSearchModel.SearchToDate,
                SearchEmployeeInsuranceId = reportSearchModel.SearchEmployeeInsuranceId,
                SearchStatusId = reportSearchModel.SearchStatusId,
                SearchVisitTypeId = reportSearchModel.SearchVisitTypeId,
                SearchClaimId = reportSearchModel.SearchClaimId,
            };
            return QueryExecutor.Query<ClaimListModel>(StoreProcedures.usp_GetTPAViewClaimsByFilter.ToString(), obj, CommandType.StoredProcedure).ToList();
        }

        public List<ServiceType> GetClaimServices(int claimId)
        {
            return QueryExecutor.Query<ServiceType>(StoreProcedures.usp_GetTPAViewClaimServices.ToString(), new { ClaimID = claimId }, CommandType.StoredProcedure).ToList();
        }

        public List<Symptoms> GetClaimSymptoms(int claimId)
        {
            return QueryExecutor.Query<Symptoms>(StoreProcedures.usp_GetTPAViewClaimSymptoms.ToString(), new { ClaimID = claimId }, CommandType.StoredProcedure).ToList();
        }
    }
}
