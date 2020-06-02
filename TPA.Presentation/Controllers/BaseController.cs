using TPA.Common.Core.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace TPA.Presentation.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        public AjaxResponse ajaxResponse;

        public BaseController()
        {
            ajaxResponse = new AjaxResponse();
        }

        protected override void ExecuteCore()
        {
            base.ExecuteCore();
        }

        protected override bool DisableAsyncSupport
        {
            get { return true; }
        }
    }
}