using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TPA.Presentation.Controllers
{
    public class CommonController : BaseController
    {
        // GET: Common
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetCitiesByCountry(string id)
        {
            List<SelectListItem> states = Dropdowns.City(0, Convert.ToInt32(id));
            return Json(new SelectList(states, "Value", "Text"),JsonRequestBehavior.AllowGet);
        }
    }
}