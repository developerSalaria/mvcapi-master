using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA.Common.Core.Model;
using TPA.Data.DAL.Repositories;

namespace TPA.Services.BusinessLogic
{
    public class ReportBL
    {
        private ReportRepository _repo;
        public ReportBL()
        {
            _repo = new ReportRepository();
        }
        
        public List<ProviderReportModel> GetServiceProviderReportsByFilters(ReportSearchModel reportSearchModel)
        {
            return _repo.GetServiceProviderReportsByFilters(reportSearchModel);
        }

        public List<PaymentReportModel> GetSearchPaymentReports(ReportSearchModel reportSearchModel)
        {
            return _repo.GetSearchPaymentReports(reportSearchModel);
        }

        public List<LossRatioReportModel> GetSearchLossRatioReports(ReportLossRatioSearchModel reportSearchModel)
        {
            return _repo.GetSearchLossRatioReports(reportSearchModel);
        }

        public void SaveProviderExcelUpload(ProviderExcelModel providerExcelModel)
        {
            _repo.SaveProviderExcelUpload(providerExcelModel);
        }
    }
}
