using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace TPA.Presentation.Helpers
{
    public static class UtilityHelper
    {
        private static int saltLengthLimit = 100;
        public static string ToAbsoluteURL(this string relativeURL)
        {
            if (string.IsNullOrEmpty(relativeURL))
            {
                return relativeURL;
            }

            if (HttpContext.Current == null)
            {
                return relativeURL;
            }

            if (relativeURL.StartsWith("/"))
            {
                relativeURL = relativeURL.Insert(0, "~");
            }

            if (!relativeURL.StartsWith("~/"))
            {
                relativeURL = relativeURL.Insert(0, "~/");
            }

            var URL = HttpContext.Current.Request.Url;
            var port = URL.Port != 80 ? (":" + URL.Port) : string.Empty;
            return string.Format("{0}://{1}{2}{3}",
                URL.Scheme, URL.Host, port, VirtualPathUtility.ToAbsolute(relativeURL));
        }

        #region --> Generate HASH Using SHA512  
        public static string Get_HASH_SHA512(string password, string username, byte[] salt)
        {
            try
            {
                //required NameSpace: using System.Text;  
                //Plain Text in Byte  
                byte[] plainTextBytes = Encoding.UTF8.GetBytes(password + username);

                //Plain Text + SALT Key in Byte  
                byte[] plainTextWithSaltBytes = new byte[plainTextBytes.Length + salt.Length];

                for (int i = 0; i < plainTextBytes.Length; i++)
                {
                    plainTextWithSaltBytes[i] = plainTextBytes[i];
                }

                for (int i = 0; i < salt.Length; i++)
                {
                    plainTextWithSaltBytes[plainTextBytes.Length + i] = salt[i];
                }

                HashAlgorithm hash = new SHA512Managed();
                byte[] hashBytes = hash.ComputeHash(plainTextWithSaltBytes);
                byte[] hashWithSaltBytes = new byte[hashBytes.Length + salt.Length];

                for (int i = 0; i < hashBytes.Length; i++)
                {
                    hashWithSaltBytes[i] = hashBytes[i];
                }

                for (int i = 0; i < salt.Length; i++)
                {
                    hashWithSaltBytes[hashBytes.Length + i] = salt[i];
                }

                return Convert.ToBase64String(hashWithSaltBytes);
            }
            catch
            {
                return string.Empty;
            }
        }
        #endregion

        #region --> Generate SALT Key  

        public static bool CompareHashValue(string password, string username, string OldHASHValue, byte[] SALT)
        {
            try
            {
                string expectedHashString = Get_HASH_SHA512(password, username, SALT);

                return (OldHASHValue == expectedHashString);
            }
            catch
            {
                return false;
            }
        }

        private static byte[] Get_SALT()
        {
            return Get_SALT(saltLengthLimit);
        }

        private static byte[] Get_SALT(int maximumSaltLength)
        {
            var salt = new byte[maximumSaltLength];

            //Require NameSpace: using System.Security.Cryptography;  
            using (var random = new RNGCryptoServiceProvider())
            {
                random.GetNonZeroBytes(salt);
            }

            return salt;
        }

        public static bool Login()
        {
            //Retrive Stored HASH Value From Database According To Username (one unique field)  
            //var userInfo = db.UserMasters.Where(s => s.Username == entity.Username.Trim()).FirstOrDefault();

            ////Assign HASH Value  
            //if (userInfo != null)
            //{
            //    OldHASHValue = userInfo.HASH;
            //    SALT = userInfo.SALT;
            //}

            bool isLogin = true;// CompareHashValue(entity.Password, entity.Username, OldHASHValue, SALT);

            if (isLogin)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string GetBaseUrl()
        {
            var request = HttpContext.Current.Request;
            var appUrl = HttpRuntime.AppDomainAppVirtualPath;

            if (appUrl != "/")
                appUrl = "/" + appUrl;

            var baseUrl = string.Format("{0}://{1}{2}", request.Url.Scheme, request.Url.Authority, appUrl);

            return baseUrl;
        }
        #endregion
    }

}