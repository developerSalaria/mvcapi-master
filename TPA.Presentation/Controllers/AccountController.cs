using TPA.Common.Core.Model;
using TPA.Presentation.ApiServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Text;
using TPA.Presentation.Helpers;
using TPA.Common.Core.Helpers;
using TPA.Common.Core.Constants;

namespace TPA.Presentation.Controllers
{
    public class AccountController : Controller
    {
       
        // GET: Account
        private UserManagementService _userService;
        public AccountController()
        {
            _userService = new UserManagementService();
        }

        public ActionResult Login()
        {
            //if (HttpContext.User.Identity.IsAuthenticated)
            //{
               // return RedirectToAction("Index", "Home");
            //}
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                var result = _userService.Login(login);
                if (result != null && !string.IsNullOrEmpty(result.AccessToken))
                {
                    FormsAuthentication.SetAuthCookie(result.UserName, true);
                    var Roles = string.IsNullOrEmpty(result.RolesName) ? "NoRole" : result.RolesName.TrimEnd(',');
                    FormsAuthenticationTicket ticket1 =
                    new FormsAuthenticationTicket(1, result.UserName, DateTime.Now, DateTime.Now.AddHours(24), true, result.AccessToken + "#" + Roles + "#" + result.UserId);
                    HttpCookie cookie1 = new HttpCookie(
                      FormsAuthentication.FormsCookieName,
                      FormsAuthentication.Encrypt(ticket1));
                    Response.Cookies.Add(cookie1);

                    UrlHelper u = new UrlHelper(this.ControllerContext.RequestContext);
                    string url = u.Action("addclaim", "claims", null);
                    return Json(new AjaxResponse() {  URL = url }, JsonRequestBehavior.AllowGet);
                }
            }

            return Json(new AjaxResponse() { ErrorMessage = TPA.Common.Core.Resources.Common.LoginFailed }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        [HttpPost]
        public JsonResult Forgot(string Email)
        {
            ResetModel result = _userService.ValidateUser(Email);
            string message="";
            if (result.IsSuccess)
            {
                string id=Convert.ToBase64String(Encoding.UTF8.GetBytes(result.Email));
               
                string url=string.Format($"{AppSettings.BaseUrl}{ApiUrls.Users.resetPassword}?token={result.Token}&id={id}");
                url = string.Format("<a href='{0}' >Click here</a> to reset password.",url);
                Email email = new Email();
                email.Send(Email, url, "TPA forgot password");
            }
            else
            {
                message = "User doesn't exist.";
            }

            return Json(new { success= result.IsSuccess, message=message});
        }

        [HttpGet]
        public ActionResult Reset(string token,string id)
        {
            //string UserEmail= Encoding.UTF8.GetString(Convert.FromBase64String(token));
            ResetModel model = new ResetModel();
            model.Email = id;
            model.Token = token;
            return View(model);
        }

        [HttpPost]
        public ActionResult Reset(ResetModel model)
        {
            string UserEmail= Encoding.UTF8.GetString(Convert.FromBase64String(model.Email));
            model.Email = UserEmail;
            
            var result = _userService.ResetPassword(model);
            return Json(result);
        }

    }
}