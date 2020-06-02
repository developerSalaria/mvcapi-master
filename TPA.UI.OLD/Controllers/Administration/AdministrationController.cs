using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using TPA.Models.Claims;

namespace TPA.Controllers.Claims
{
    public class AdministrationController : Controller
    {
        // GET: Claims
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetRoles(string com)
        {
            List<ClaimsModel> obj = new List<ClaimsModel>(){
                new ClaimsModel{
            claimID = "User",
            provider = "Active",
            insuranceNo = "12 Apr, 2019",
            visitType = "test-al-Basrah",
            visitDate = "12 Apr, 2019"          
        } ,
                new ClaimsModel{
            claimID = "Admin",
            provider = "Active",
            insuranceNo = "14 Apr, 2019",
            visitType = "test-Baghdad",
            visitDate = "15 Apr, 2019"
        } ,
                new ClaimsModel{
            claimID = "Doctor",
            provider = "Active",
            insuranceNo = "14 Apr, 2019",
            visitType = "test-Baghdad",
            visitDate = "15 Apr, 2019"
        }
            };
            
            var count = 3;
            var listSerialized = new
            {
                draw = 1,
                recordsFiltered = count,
                recordsTotal = count,
                data = obj
            };
            return Json(listSerialized, JsonRequestBehavior.AllowGet);
        }
    }
}
