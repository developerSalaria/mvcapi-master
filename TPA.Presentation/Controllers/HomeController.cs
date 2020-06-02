using TPA.Presentation.ApiServices;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace TPA.Presentation.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var IsTrue = User.IsInRole("Accountant");
            var AuthenticationType = HttpContext.User.Identity.AuthenticationType;
            var IsAuthenticated = HttpContext.User.Identity.IsAuthenticated;
            Dropdowns.CompareCurrentLang(true);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ElmahTest()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        [AllowAnonymous]
        public ActionResult SelectLanguage(string lang)
        {
            SelectLanuage(lang);
            string url = this.Request.UrlReferrer.AbsolutePath;
            return Redirect(url);
        }

        [AllowAnonymous]
        public ActionResult SelectLanguageForLogin(string lang)
        {
            SelectLanuage(lang);
            return RedirectToAction("Login", "Account");
        }

        private void SelectLanuage(string lang)
        {
            if (!string.IsNullOrEmpty(lang))
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
            }

            HttpCookie cookie = new HttpCookie("Language");
            cookie.Value = lang;
            Response.Cookies.Add(cookie);
        }

        [HttpGet]
        public JsonResult SetLanguageInCache()
        {
            Dropdowns.CompareCurrentLang(true);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}