using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TPA.Models;

namespace TPA.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index(int timeoutflag = 0)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.ErroMsg = TempData["ErrorMsg"];
            TempData["ErrorMsg"] = "";
            if (timeoutflag == 1)
            {
                ViewBag.ErroMsg = "Session has expired ... Please login again";

            }
            //  iWrite("4-" + Thread.CurrentThread.CurrentCulture.Name);
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> UserLogin(User userViewModel)
        {
            //System.Threading.Thread.Sleep(119000);
            return RedirectToAction("Index", "Home");
            var response = await UI.Helper.HttpClientUtility.GetTokenResponse<TokenModel>(userViewModel, "token");
            if (response.IsSuccessful)
            {

                //----
                SetCookieValue(response.Model.access_token, "New_TPA_Token_Cookies_" + System.Web.Configuration.WebConfigurationManager.AppSettings["Environment"]);
                #region To be removed later
                SetCookieValue(response.Model.access_token, "tokenCookies");
                SetCookieValue(response.Model.access_token, ".AspNet.ApplicationCookie");
                #endregion
                //----
                var claims = new List<Claim>();
                // Setting    

                claims.Add(new Claim(ClaimTypes.Name, response.Model.user));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, response.Model.user));
                claims.Add(new Claim(ClaimTypes.Expired, response.Model.expires));
                claims.Add(new Claim("LaborOffice", response.Model.userLaborOffice));
                claims.Add(new Claim("userId", response.Model.userId));
                claims.Add(new Claim("userAdId", response.Model.userAdId));
                claims.Add(new Claim("userArabicName", response.Model.userArabicName));
                claims.Add(new Claim("userEnglishName", response.Model.userEnglishName));
                claims.Add(new Claim("userLastLogin", response.Model.userLastLogin));
                claims.Add(new Claim("laborOfficeNameAr", response.Model.laborOfficeNameAr));
                claims.Add(new Claim("laborOfficeNameEn", response.Model.laborOfficeNameEn));

                var claimIdenties = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
                var ctx = Request.GetOwinContext();
                var authenticationManager = ctx.Authentication;
                // Sign In.    
                authenticationManager.SignIn(new AuthenticationProperties(), claimIdenties);


                //return RedirectToActionPermanent("MainPage");
                return Json(new { success = true, resposneTxt = Url.Action("Index", "Home") }, JsonRequestBehavior.AllowGet);
            }
            //TempData["ErrorMsg"] = (System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToLowerInvariant() == "ar-ae" ? response.MessageAr : response.MessageEn);
            return Json(new { success = false, message = TempData["ErrorMsg"], resposneTxt = Url.Action("Index", "Login") }, JsonRequestBehavior.AllowGet);

            //return RedirectToActionPermanent("Index");
        }

        // maybe move to base class, for now it is fine
        protected string SetCookieValue(string value, string name)
        {
            HttpCookie tokenCookies = new HttpCookie(name);
            tokenCookies.HttpOnly = true;
            //tokenCookies.Secure = true;
            tokenCookies.Value = value;
            tokenCookies.Expires = DateTime.Now.AddHours(24);
            Response.SetCookie(tokenCookies);
            return "";
        }
    }
}