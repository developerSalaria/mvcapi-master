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
    public class VisitTypeService : HttpClientService
    {
        static VisitTypeService _instance;

        public static VisitTypeService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new VisitTypeService();
                }
                return _instance;
            }
        }

        public List<VisitType> Get()
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.VisitTypeApiURL.Get);
            var Content = Get<List<VisitType>>(URL);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return new List<VisitType>();
            }
        }

        public VisitType GetById(int visitTypeId)
        {
            var URL = string.Format($"{AppSettings.BaseApiUrl}{ApiUrls.VisitTypeApiURL.GET_BY_ID}?visitTypeId={visitTypeId}");
            var Content = Get<VisitType>(URL);
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