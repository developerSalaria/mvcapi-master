using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPA.Models
{
    public class TokenModel
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string expires_in { get; set; }
        public string accessCode { get; set; }
        public string user { get; set; }
        public string issued { get; set; }
        public string expires { get; set; }

        public string userLaborOffice { get; set; }

        public string userId { get; set; }
        public string userAdId { get; set; }
        public string userArabicName { get; set; }
        public string userEnglishName { get; set; }
        public string userLastLogin { get; set; }
        public string laborOfficeNameAr { get; set; }
        public string laborOfficeNameEn { get; set; }
    }
}