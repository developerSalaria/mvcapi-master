using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using TPA.Common.Core.MobileModel;
using TPA.MobileAPI.Common;
using TPA.Services.BusinessLogic.MobileBAL;

namespace TPA.MobileAPI.Provider
{
    public class AuthorizationServiceProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            using (UserBL _bal = new UserBL())
            {
                UserModel user = new UserModel() {Email= context.UserName };
                user = _bal.GetUser(user);
                user.UserRoles = "Admin";
                if (user == null||Utility.Decrypt(user.Password)!=context.Password)
                {
                    context.SetError("invalid_grant", "Provided username and password is incorrect");
                    return;
                }
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Role, user.UserRoles));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.Email));
                identity.AddClaim(new Claim("Email", user.Email));
                identity.AddClaim(new Claim("EmployeeCode", user.EmployeeCode));
                identity.AddClaim(new Claim("PolicyCode", user.PolicyCode));
                context.Validated(identity);
            }
        }
    }
}