using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TPA.Common.Core.Model;

namespace TPA.Presentation.Controllers
{
    public class UserManagerController : Controller
    {
        #region Methods


        #region User Manage
        /// <summary>
        /// Get List of users 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        /// <summary>
        /// Get List of users
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            return View();
        }

        /// <summary>
        /// Get List of Users
        /// </summary>
        /// <returns></returns>
        public ActionResult GetUsers()
        {
            var allUser = ApiServices.AccountService.Instance.GetUsers();
            return Json(new
            {
                draw = "1",
                data = allUser,
                recordsFiltered = allUser.Count,
                recordsTotal = allUser.Count,
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Add/Edit GET =>Open User Modal
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AddEditUser(string userId)
        {
            UserViewModel userViewModel = new UserViewModel();
            try
            {
                var allRoles = ApiServices.AccountService.Instance.GetRoles();
                //Create list for role
                var roleList = allRoles.Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id
                }).ToList();

                userViewModel.RoleList = roleList;

                //Edit user case 
                if (!string.IsNullOrEmpty(userId))
                {
                    var user = ApiServices.AccountService.Instance.GetUserById(userId);
                    ViewBag.headerTitle = "Edit User";
                    if (user != null)
                    {
                        userViewModel.UserName = user.UserName;
                        userViewModel.Email = user.Email;
                        userViewModel.Id = user.Id;
                        var userRole = ApiServices.AccountService.Instance.GetUserRolesById(user.Id);
                        if (userRole != null)
                        {
                            userViewModel.SelectedRole = userRole.ToArray();
                        }
                    }
                }

                //Add user case
                else
                {
                    ViewBag.headerTitle = "Add User";
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return View(userViewModel);
        }

        /// <summary>
        /// Add new user 
        /// </summary>
        /// <param name="userViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public string AddEditUser(UserViewModel userViewModel)
        {
            try
            {
                //if (!ModelState.IsValid)
                //{
                //    return "please enter valid data!";
                //}

                //Edit user case
                if (userViewModel.Id != null)
                {
                    var result = ApiServices.AccountService.Instance.UpdateUser(userViewModel);
                }

                //Add user case
                else
                {
                    var result = ApiServices.AccountService.Instance.Register(userViewModel);
                }
            }
            catch (Exception ex)
            {
                return "something went wrong!";
            }
            return "user added successfully!";
        }

        /// <summary>
        /// Delete User By User Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<bool> DeleteUserById(string userId)
        {
            try
            {
                var result = ApiServices.AccountService.Instance.DeleteUserById(userId);
            }
            catch (Exception ex)
            {
            }
            return false;
        }
        #endregion


        #endregion
    }
}