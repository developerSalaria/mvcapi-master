using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;

namespace TPA.Common.Core.Model
{
   public class AjaxResponse
    {
        public bool IsSuccess {
            get
            {
                if (ErrorMessage == null || string.IsNullOrEmpty(ErrorMessage.Trim()))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public string Message { get; set; }
        public string ErrorMessage { get; set; }
        public string URL { get; set; }
        public List<string> modelErrorList { get; set; }
    }
}
