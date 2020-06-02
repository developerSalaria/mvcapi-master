using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TPA.Common.Core.Model;

namespace TPA.Presentation.Controllers
{
    public class RoleManagerController : Controller
    {
        #region Methods

        #region Role Manage
        
        /// <summary>
        /// Get List of Roles 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        /// <summary>
        /// Get List of Roles
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            return View();
        }

        /// <summary>
        /// Get List of Roles
        /// </summary>
        /// <returns></returns>
        public ActionResult GetRoles()
        {
            var allRoles = ApiServices.AccountService.Instance.GetRoles();
            return Json(new
            {
                draw = "1",
                data = allRoles,
                recordsFiltered = allRoles.Count,
                recordsTotal = allRoles.Count,
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Add/Edit GET =>Open User Modal
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AddEditRole(string roleId)
        {
            RoleViewModel roleViewModel = new RoleViewModel();
            try
            {
                //Edit user case 
                if (!string.IsNullOrEmpty(roleId))
                {
                    var role = ApiServices.AccountService.Instance.GetRoleById(roleId);
                    ViewBag.headerTitle = "Edit Role";
                    if (role != null)
                    {
                        roleViewModel.Id = role.Id;
                        roleViewModel.Name = role.Name;
                    }
                }

                //Add user case
                else
                {
                    ViewBag.headerTitle = "Add Role";
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return View(roleViewModel);
        }

        /// <summary>
        /// Add Edit Role POST
        /// </summary>
        /// <param name="roleViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public string AddEditRole(RoleViewModel roleViewModel)
        {
            try
            {
                //Edit role case
                if (roleViewModel.Id != null)
                {
                    var result = ApiServices.AccountService.Instance.UpdateRole(roleViewModel);
                }

                //Add role case
                else
                {
                    var result = ApiServices.AccountService.Instance.AddNewRole(roleViewModel);
                }
            }
            catch (Exception ex)
            {
                return "something went wrong!";
            }
            return "user added successfully!";
        }


        /// <summary>
        /// Delete Role By  Id
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<bool> DeleteRoleById(string roleId)
        {
            try
            {
                var result = ApiServices.AccountService.Instance.DeleteRoleById(roleId);
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