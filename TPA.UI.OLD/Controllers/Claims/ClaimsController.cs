using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using TPA.Models.Claims;

namespace TPA.Controllers.Claims
{
    public class ClaimsController : Controller
    {
        // GET: Claims
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetClaims(string com)
        {
            List<ClaimsModel> obj = new List<ClaimsModel>(){
                new ClaimsModel{
            claimID = "Test-Al-Musawy Private Hospital",
            provider = "07704944722",
            insuranceNo = "test-Mhosp05@yahoo.com",
            visitType = "test-al-Basrah",
            visitDate = "12 Apr, 2019"          
        } ,
                new ClaimsModel{
            claimID = "Test2-Al-Alamy Hospital",
            provider = "07704944722",
            insuranceNo = "test2-info@alamyhospital.com",
            visitType = "test-Baghdad",
            visitDate = "15 Apr, 2019"
        } 
            };
            
            var count = 2;
            var listSerialized = new
            {
                draw = 1,
                recordsFiltered = count,
                recordsTotal = count,
                data = obj
            };
            return Json(listSerialized, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddClaim()
        {
            return View();
        }

        public ActionResult ViewClaim(string claimId)
        {
            return View();
        }
    }
}
