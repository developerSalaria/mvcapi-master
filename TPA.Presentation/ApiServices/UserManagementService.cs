using TPA.Common.Core.Constants;
using TPA.Common.Core.Helpers;
using TPA.Common.Core.Model;
using TPA.Common.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace TPA.Presentation.ApiServices
{
    public class UserManagementService : HttpClientService
    {
        public Token Login(Login login)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Users.getToken);
            var Content = PostToken<Token>(URL, new { username = login.UserName, password = login.Password });
           
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return new Token() { ValidationMessage = new ValidationMessage() { Message = Content.Message } };
            }
        }

        public ResetModel ResetPassword(ResetModel model)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Users.ResetPassword);
            var Content = PostToken<ResetModel>(URL, model);

            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return new ResetModel();
            }
        }
        public ResetModel ValidateUser(string Email)
        {
            var URL = string.Format($"{AppSettings.BaseApiUrl}{ApiUrls.Users.validateUser}?Email={Email}");
            var Content = Get<ResetModel>(URL);

            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return new ResetModel();
            }
        }

        //public List<Users> GetAllUsers()
        //{
        //    var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Users.GetUsers);
        //    var Content = Get<List<Users>>(URL);
        //    return Content.Model;
        //}

        //public Users GetUserById(int UserId)
        //{
        //    var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Users.GetUsersByUsersId, UserId);
        //    var Content = Get<Users>(URL);
        //    if (Content.IsSuccessful)
        //    {
        //        return Content.Model;
        //    }
        //    else
        //    {
        //        return new Users() { ValidationMessage = new ValidationMessage() { ErrorMessage = Content.Message } };
        //    }
        //}

        //public ValidationMessage DeleteUser(int UserId)
        //{
        //    var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Users.DeleteUsersByUsersId, UserId);
        //    var Content = Post<string>(URL);
        //    if (Content.IsSuccessful)
        //    {
        //        return new ValidationMessage();
        //    }
        //    else
        //    {
        //        return new ValidationMessage() { ErrorMessage = Content.Message };
        //    }
        //}

        //public ValidationMessage UpdateUser(Users User)
        //{
        //    var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Users.UpdateUsers);
        //    var Content = Post<string>(URL, User);
        //    if (Content.IsSuccessful)
        //    {
        //        return new ValidationMessage();
        //    }
        //    else
        //    {
        //        return new ValidationMessage() { ErrorMessage = Content.Message };
        //    }
        //}

        //public ValidationMessage AddUser(Users User)
        //{
        //    var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Users.InsertUsers);
        //    var Content = Post<string>(URL, User);
        //    if (Content.IsSuccessful)
        //    {
        //        return new ValidationMessage();
        //    }
        //    else
        //    {
        //        return new ValidationMessage() { ErrorMessage = Content.Message };
        //    }
        //}
    }
}