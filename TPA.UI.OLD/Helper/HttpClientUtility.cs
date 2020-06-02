 using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TPA.Common.Core.Model;
using TPA.Models;

namespace TPA.UI.Helper
{
    public class HttpClientUtility
    {
        static string baseAddress = System.Configuration.ConfigurationManager.AppSettings["BaseAddress"].ToString();
        public static string secretKeyCki = "r0b1nr0y";

        public static HttpClient CreateHttpClient()
        {

            HttpClientHandler handler = new HttpClientHandler() { UseDefaultCredentials = false };
            HttpClient client = new HttpClient(handler);
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
            return client;
        }

        public async static Task<ApiResponse<T>> GetTokenResponse<T>(User userViewModel, string methodName)
        {
            using (var client = CreateHttpClient())
            {
                //string body = $"grant_type=password&username={userViewModel.UserId.ToUpper()}&password={userViewModel.Password}";
                //request.Content = new StringContent(body, Encoding.UTF8, "application/x-www-form-urlencoded");//CONTENT-TYPE header

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress + "/" + methodName);
                request.Content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("username", userViewModel.UserId.ToUpper()),
                    new KeyValuePair<string, string>("password", userViewModel.Password)
                });

                var response = await client.SendAsync(request);
                var apiResponse = new ApiResponse<T>(response.StatusCode);
                if (!response.IsSuccessStatusCode)
                {
                    var responseTxt = response.Content.ReadAsStringAsync().Result;
                    dynamic json = JsonConvert.DeserializeObject(responseTxt.Trim());
                    string jsonErrorStr = json.error;
                    dynamic errorJson = JsonConvert.DeserializeObject(jsonErrorStr);
                    //apiResponse.MessageEn = errorJson.MessageEn;
                    //apiResponse.MessageAr = errorJson.MessageAr;
                }
                else
                {
                    if (typeof(T) == typeof(byte[]))
                    {
                        apiResponse.Model = (T)(object)(await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false));
                    }
                    else
                    {
                        #region Load token
                        var result = response.Content.ReadAsStringAsync().Result;
                        dynamic obj = JsonConvert.DeserializeObject(result);
                        var jo = JObject.Parse(result);
                        TokenModel d = new TokenModel();
                        d.access_token = jo["access_token"].ToString();
                        d.token_type = jo["token_type"].ToString();
                        d.expires_in = jo["expires_in"].ToString();
                        d.accessCode = jo["accessCode"].ToString();
                        d.user = jo["user"].ToString();
                        d.issued = jo[".issued"].ToString();
                        d.expires = jo[".expires"].ToString();
                        d.userLaborOffice = jo["userLaborOffice"].ToString();

                        d.userId = jo["userId"].ToString();
                        d.userAdId = jo["userAdId"].ToString();
                        d.userArabicName = jo["userArabicName"].ToString();
                        d.userEnglishName = jo["userEnglishName"].ToString();
                        d.userLastLogin = jo["userLastLogin"].ToString();
                        d.laborOfficeNameAr = jo["laborOfficeNameAr"].ToString();
                        d.laborOfficeNameEn = jo["laborOfficeNameEn"].ToString();

                        apiResponse.Model = (T)(object)d;
                        #endregion
                    }
                }
                return apiResponse;
            }
        }

        public async static Task<HttpResponseMessage> CallForResponse<I, T>(I Info, string methodWithParam, string type, bool isNew)
        {
            HttpResponseMessage response = null;
            var baseUrl = baseAddress;
            string url = baseAddress + "/" + methodWithParam;

            var myContent = JsonConvert.SerializeObject(Info);
            var buffer = Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var ctx = HttpContext.Current;
            string token = ctx.Request.Cookies["New_OraMenu_Token_Cookies_" + System.Web.Configuration.WebConfigurationManager.AppSettings["Environment"]]?.Value;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.Timeout = TimeSpan.FromHours(1);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (type == "post")
                    response = await client.PostAsync(url, byteContent).ConfigureAwait(false);
                else
                    response = await client.GetAsync(url).ConfigureAwait(false);

                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    ctx.Session.RemoveAll();
                    ctx.Request.GetOwinContext().Authentication.SignOut();
                    ctx.Response.Redirect("~/error.html");
                }

                return response;
               
            }
        }

        public async static Task<ApiResponse<T>> GetTokenResponse<I, T>(I Info, string methodWithParam, string type, string token = "")
        {
            var response = await CallForResponse<I, T>(Info, methodWithParam, type, false).ConfigureAwait(false);
            var apiResponse = new ApiResponse<T>(response.StatusCode);
            if (!response.IsSuccessStatusCode)
            {
                //apiResponse.MessageEn = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
            else
            {
                if (typeof(T) == typeof(byte[]))
                {
                    apiResponse.Model = (T)(object)(response.Content.ReadAsByteArrayAsync().ConfigureAwait(false));
                }
                else
                {
                    var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    apiResponse.Model = JsonConvert.DeserializeObject<T>(result);
                }
            }
            return apiResponse;
        }

        public async static Task<T> NewGetTokenResponse<I, T>(I Info, string methodWithParam, string type, string token = "")
        {
            var response = await CallForResponse<I, T>(Info, methodWithParam, type, true).ConfigureAwait(false);
            if (typeof(T) == typeof(byte[]))
            {
                return (T)(object)(await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false));
            }
            else
            {
                var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return JsonConvert.DeserializeObject<T>(result);
            }
        }
    }
}