using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA.Common.Core.Model;

namespace TPA.Data.DAL.Repositories
{
    public class ReportRepository : BaseRepository
    {

        /// <summary>
        /// Get Provider Reports By Filters
        /// </summary>
        /// <param name="reportSearchModel"></param>
        /// <returns></returns>
        public List<ProviderReportModel> GetServiceProviderReportsByFilters(ReportSearchModel reportSearchModel)
        {
            var obj = new
            {
                SearchProvider   =    reportSearchModel.SearchProvider,
                SearchContactractor = reportSearchModel.SearchContactractor,
                SearchEmployeeName  = reportSearchModel.SearchEmployeeName,
                SearchFromDate =      reportSearchModel.SearchFromDate,
                SearchToDate =        reportSearchModel.SearchToDate,
                SearchEmployeeInsuranceId = reportSearchModel.SearchEmployeeInsuranceId,
                SearchStatusId =      reportSearchModel.SearchStatusId,
                SearchVisitTypeId =   reportSearchModel.SearchVisitTypeId,
                SearchClaimId = reportSearchModel.SearchClaimId,
            };
            return QueryExecutor.Query<ProviderReportModel>(StoreProcedures.usp_GetTPAClaimsReportForServiceProvider.ToString(), obj, CommandType.StoredProcedure).ToList();
        }

        public List<PaymentReportModel> GetSearchPaymentReports(ReportSearchModel reportSearchModel)
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
                searchPaymentStatusId = reportSearchModel.searchPaymentStatusId,
            };
            return QueryExecutor.Query<PaymentReportModel>(StoreProcedures.usp_GetTPAClaimsReportForPaymentReport.ToString(), obj, CommandType.StoredProcedure).ToList();
        }

        public List<LossRatioReportModel> GetSearchLossRatioReports(ReportLossRatioSearchModel reportSearchModel)
        {
            var obj = new
            {
                SearchPolicy = reportSearchModel.SearchPolicy,
                SearchCompanyName = reportSearchModel.SearchCompanyName,
            };
            return QueryExecutor.Query<LossRatioReportModel>(StoreProcedures.usp_GetTPAReportForLossRatio.ToString(), obj, CommandType.StoredProcedure).ToList();
        }

        public void SaveProviderExcelUpload(ProviderExcelModel item)
        {
            DataTable dt = new DataTable();
            dt.TableName = "ProviderReport";

            dt.Columns.Add("ClaimNumber", typeof(string));
            dt.Columns.Add("InsuredName", typeof(string));
            dt.Columns.Add("PolicyCode", typeof(string));
            dt.Columns.Add("Provider", typeof(string));
            dt.Columns.Add("Visittype", typeof(string));
            dt.Columns.Add("VisitDate", typeof(string));
            dt.Columns.Add("PaymentInfo", typeof(string));
            dt.Columns.Add("Status", typeof(string));
            dt.Columns.Add("LastModified", typeof(string));
            dt.Columns.Add("ProviderNotes", typeof(string));
            dt.Columns.Add("AuditorNotes", typeof(string));
            dt.Columns.Add("ServiceName", typeof(string));
            dt.Columns.Add("ServiceType", typeof(string));
            dt.Columns.Add("Servicesubtype", typeof(string));
            dt.Columns.Add("Coshareamount", typeof(string));
            dt.Columns.Add("Insured", typeof(string));
            dt.Columns.Add("Price", typeof(string));

            dt.Columns.Add("CoShareType", typeof(string));
            dt.Columns.Add("CoShare", typeof(string));
            dt.Columns.Add("ServiceStatus", typeof(string));
            dt.Columns.Add("Symptoms", typeof(string));
            dt.Columns.Add("InsuranceCompany", typeof(string));
            dt.Columns.Add("PolicyNumber", typeof(string));
            //dt.Columns.Add("SubPolicy", typeof(string));
            dt.Columns.Add("PaymentStatus", typeof(string));
            dt.Columns.Add("PaymentDate", typeof(string));
            //dt.Columns.Add("DOB", typeof(string));
            //dt.Columns.Add("VisitorName", typeof(string));
            //dt.Columns.Add("PaymentLastmodifiedby", typeof(string));
            dt.Columns.Add("PaymentDetails", typeof(string));
            //dt.Columns.Add("PaymentLastmodifiedDate", typeof(string));
            dt.Columns.Add("PaymentReference", typeof(string));




            DataRow row = dt.NewRow();
            row["ClaimNumber"] = item.ClaimNumber;
            row["InsuredName"] = item.InsuredName;
            row["PolicyCode"] = item.PolicyCode;
            row["Provider"] = item.Provider;
            row["Visittype"] = item.Visittype;
            row["VisitDate"] = DateTime.Now;//item.VisitDate;
            row["PaymentInfo"] = item.PaymentInfo;
            row["Status"] = item.Status;
            row["LastModified"] = DateTime.Now;//item.LastModified;
            row["ProviderNotes"] = item.ProviderNotes;
            row["AuditorNotes"] = item.AuditorNotes;
            row["ServiceName"] = item.ServiceName;
            row["ServiceType"] = item.ServiceType;
            row["Servicesubtype"] = item.Servicesubtype;
            row["Coshareamount"] = item.Coshareamount;
            row["Insured"] = item.Insured;
            row["Price"] = item.Price;
            row["CoShareType"] = item.CoShareType;
            row["CoShare"] = item.CoShare;

            row["ServiceStatus"] = item.ServiceStatus;
            row["Symptoms"] = item.Symptoms;
            row["InsuranceCompany"] = item.InsuranceCompany;
            row["PolicyNumber"] = item.PolicyNumber;
            //row["SubPolicy"] = item.SubPolicy;
            row["PaymentStatus"] = item.PaymentStatus;
            //row["PaymentLastmodifiedby"] = item.PaymentLastmodifiedby;

            row["PaymentDate"] = item.PaymentDate;
            //row["PaymentLastmodifiedDate"] = item.PaymentLastmodifiedDate;
            row["PaymentDetails"] = item.PaymentDetails;

            row["PaymentReference"] = DateTime.Now; //item.PaymentDate;


            dt.Rows.Add(row);





            var ret = QueryExecutor.Query<string>(StoreProcedures.usp_InsertProviderClaimExcelData.ToString(), new { tblProviderExcelUpload = dt }, CommandType.StoredProcedure);
        }
    }
}
