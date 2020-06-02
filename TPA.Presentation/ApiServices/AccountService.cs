using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPA.Common.Core.Constants;
using TPA.Common.Core.Helpers;
using TPA.Common.Core.Model;
using TPA.Common.Core.Services;

namespace TPA.Presentation.ApiServices
{
    public class AccountService : HttpClientService
    {
       static AccountService _instance;

        public static AccountService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AccountService();
                }
                return _instance;
            }
        }

        #region User Management 

        /// <summary>
        /// Register new user
        /// </summary>
        /// <param name="userViewModel"></param>
        /// <returns></returns>
        public int Register(UserViewModel userViewModel)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.AccountApiURL.Register);
            var Content = Post<int>(URL, userViewModel);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="userViewModel"></param>
        /// <returns></returns>
        public int UpdateUser(UserViewModel userViewModel)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.AccountApiURL.UpdateUser);
            var Content = Post<int>(URL, userViewModel);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return 0;
            }
        }
       
        /// <summary>
        /// Get All Users List
        /// </summary>
        /// <returns></returns>
        public List<UserViewModel> GetUsers()
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.AccountApiURL.GetUsers);
            var Content = Get<List<UserViewModel>>(URL);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return new List<UserViewModel>();
            }
        }

        /// <summary>
        /// Delete User By user Id
        /// </summary>
        /// <returns></returns>
        public int DeleteUserById(string userId)
        {
            var URL = string.Format($"{AppSettings.BaseApiUrl}{ApiUrls.AccountApiURL.DeleteUserById}?userId={userId}");
            var Content = Post<int>(URL);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Get User By Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UserViewModel GetUserById(string userId)
        {
            var URL = string.Format($"{AppSettings.BaseApiUrl}{ApiUrls.AccountApiURL.GetUserById}?userId={userId}");
            var Content = Get<UserViewModel>(URL);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// Get User Roles By Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string[] GetUserRolesById(string userId)
        {
            var URL = string.Format($"{AppSettings.BaseApiUrl}{ApiUrls.AccountApiURL.GetUserRolesById}?userId={userId}");
            var Content = Get<string[]>(URL);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return null;
            }
        }
        #endregion


        #region Role Management 

        /// <summary>
        /// Get All Roles List
        /// </summary>
        /// <returns></returns>
        public List<RoleViewModel> GetRoles()
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.AccountApiURL.GetRoles);
            var Content = Get<List<RoleViewModel>>(URL);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return new List<RoleViewModel>();
            }
        }

        /// <summary>
        /// Get Role By Id
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public RoleViewModel GetRoleById(string roleId)
        {
            var URL = string.Format($"{AppSettings.BaseApiUrl}{ApiUrls.AccountApiURL.GetRoleById}?roleId={roleId}");
            var Content = Get<RoleViewModel>(URL);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Add new role
        /// </summary>
        /// <param name="userViewModel"></param>
        /// <returns></returns>
        public int? AddNewRole(RoleViewModel roleViewModel)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.AccountApiURL.AddNewRole);
            var Content = Post<int?>(URL, roleViewModel);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Update Role
        /// </summary>
        /// <param name="roleViewModel"></param>
        /// <returns></returns>
        public int UpdateRole(RoleViewModel roleViewModel)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.AccountApiURL.UpdateRole);
            var Content = Post<int>(URL, roleViewModel);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Delete Role By role Id
        /// </summary>
        /// <returns></returns>
        public int DeleteRoleById(string roleId)
        {
            var URL = string.Format($"{AppSettings.BaseApiUrl}{ApiUrls.AccountApiURL.DeleteRoleById}?roleId={roleId}");
            var Content = Post<int>(URL);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return 0;
            }
        }
        #endregion
    }
}