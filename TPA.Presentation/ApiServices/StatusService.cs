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
    public class StatusService : HttpClientService
    {
        static StatusService _instance;

        public static StatusService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new StatusService();
                }
                return _instance;
            }
        }
        public List<Status> Get()
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.StatusApiURL.Get);
            var Content = Get<List<Status>>(URL);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return new List<Status>();
            }
        }

        public Status GetById(int statusId)
        {
            var URL = string.Format($"{AppSettings.BaseApiUrl}{ApiUrls.StatusApiURL.GET_BY_ID}?statusId={statusId}");
            var Content = Get<Status>(URL);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return null;
            }
        }
    }
}