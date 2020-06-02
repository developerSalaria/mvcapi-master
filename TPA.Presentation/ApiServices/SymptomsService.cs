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
    public class SymptomsService : HttpClientService
    {
        static SymptomsService _instance;

        public static SymptomsService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SymptomsService();
                }
                return _instance;
            }
        }

        public List<Symptoms> Get()
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.SymptomsApiURL.Get);
            var Content = Get<List<Symptoms>>(URL);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return new List<Symptoms>();
            }
        }
    }
}