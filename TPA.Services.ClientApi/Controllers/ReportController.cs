using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using TPA.Common.Core.Model;
using TPA.Services.BusinessLogic;

namespace TPA.Services.ClientApi.Controllers
{
    public class ReportController : BaseApiController
    {
        private ReportBL _repo;
        public ReportController()
        {
            _repo = new ReportBL();
        }
       
        [HttpPost] 
        [Route(URLs.ReportURL.SearchServiceProviderReport)]
        public HttpResponseMessage SearchServiceProviderReport(ReportSearchModel reportSearchModel)
        {
            return OKResponse(_repo.GetServiceProviderReportsByFilters(reportSearchModel));
        }
        

        [HttpPost]
        [Route(URLs.ReportURL.SearchPaymentReports)]
        public HttpResponseMessage SearchPaymentReports(ReportSearchModel reportSearchModel)
        {
            return OKResponse(_repo.GetSearchPaymentReports(reportSearchModel));
        }

        [HttpPost]
        [Route(URLs.ReportURL.SearchLossRatioReports)]
        public HttpResponseMessage SearchLossRatioReports(ReportLossRatioSearchModel reportSearchModel)
        {
            return OKResponse(_repo.GetSearchLossRatioReports(reportSearchModel));
        }

        [HttpPost]

        [Route(URLs.ReportURL.ProviderExcelUpload)]
        public HttpResponseMessage ProviderExcelUpload(ProviderExcelModel model)
        {
            _repo.SaveProviderExcelUpload(model);

            return OKResponse(true);

        }
    }
}