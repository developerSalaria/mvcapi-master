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
    public class DoctorSpecialityService : HttpClientService
    {
        static DoctorSpecialityService _instance;

        public static DoctorSpecialityService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DoctorSpecialityService();
                }
                return _instance;
            }
        }

        public List<DoctorSpeciality> Get()
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.DoctorSpecialityApiURL.Get);
            var Content = Get<List<DoctorSpeciality>>(URL);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return new List<DoctorSpeciality>();
            }
        }

        public DoctorSpeciality GetById(int doctorSpecialityId)
        {
            var URL = string.Format($"{AppSettings.BaseApiUrl}{ApiUrls.DoctorSpecialityApiURL.GET_BY_ID}?doctorSpecialityId={doctorSpecialityId}");
            var Content = Get<DoctorSpeciality>(URL);
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