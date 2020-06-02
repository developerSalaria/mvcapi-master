using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TPA.Common.Core.Constants;
using TPA.Common.Core.Helpers;
using TPA.Common.Core.Model;
using TPA.Common.Core.Services;

namespace TPA.Presentation.ApiServices
{
    public class ReportService : HttpClientService
    {
        static ReportService _instance;

        public static ReportService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ReportService();
                }
                return _instance;
            }
        }

        /// <summary>
        /// Get Reports By Filters
        /// </summary>
        /// <param name="reportSearchModel"></param>
        /// <returns></returns>
        public List<ProviderReportModel> GetServiceProviderReportsByFilters(ReportSearchModel reportSearchModel)
        {
            var URL = string.Format($"{AppSettings.BaseApiUrl}{ApiUrls.SearchReportApiURL.GetProviderReports}");
            var Content = Post<List<ProviderReportModel>>(URL, reportSearchModel);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return new List<ProviderReportModel>();
            }
        }

        public List<PaymentReportModel> SearchPaymentReports(ReportSearchModel reportSearchModel)
        {
            var URL = string.Format($"{AppSettings.BaseApiUrl}{ApiUrls.SearchReportApiURL.SearchPaymentReports}");
            var Content = Post<List<PaymentReportModel>>(URL, reportSearchModel);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return new List<PaymentReportModel>();
            }
        }

        public List<LossRatioReportModel> SearchLossRatioReports(ReportLossRatioSearchModel reportSearchModel)
        {
            var URL = string.Format($"{AppSettings.BaseApiUrl}{ApiUrls.SearchReportApiURL.SearchLossRatioReports}");
            var Content = Post<List<LossRatioReportModel>>(URL, reportSearchModel);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return new List<LossRatioReportModel>();
            }
        }

        public void UpdateProviderExcel(ProviderExcelModel model)
        {

            var URL = string.Format($"{AppSettings.BaseApiUrl}{ApiUrls.SearchReportApiURL.ProviderExcelUpload}");
            var Content = Post<string>(URL, model);
            if (Content.IsSuccessful)
            {
                //return Content.Model;
            }
            else
            {
                //return new List<LossRatioReportModel>();
            }
        }
    }
}