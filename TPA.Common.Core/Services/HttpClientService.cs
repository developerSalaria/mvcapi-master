using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Security.Claims;
using TPA.Common.Core.Model;
using TPA.Common.Core.Constants;
using System.Web;

namespace TPA.Common.Core.Services
{
   public class HttpClientService
    {
        static HttpClient _httpClient = new HttpClient(new HttpClientHandler { UseCookies = false });

        static HttpClientService()
        {
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MimeTypes.JSON));
        }

        public ApiResponse<T> Get<T>(string uri) where T : class
        {
            return Send<T>(uri, HttpMethod.Get);
        }

        public ApiResponse<T> Post<T>(string uri, object input = null)
        {
            return Send<T>(uri, HttpMethod.Post,input);
        }

        public ApiResponse<T> PostToken<T>(string uri, object input = null) where T : class
        {
            return GetToken<T>(uri, HttpMethod.Post, input);
        }

        private static ApiResponse<T> Send<T>(string uri, HttpMethod method, object input = null)
        {
            var request = new HttpRequestMessage(method, uri);
            if(input != null)
            {
                var content = new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, MimeTypes.JSON);
                request.Content = content;
            }

            var identity = HttpContext.Current.User.Identity as ClaimsIdentity;
            var accessToken = identity.Claims.Where(x => x.Type == "MyToken").FirstOrDefault();
            var myUserId = identity.Claims.Where(x => x.Type == "MyUserId").FirstOrDefault();
            if (accessToken != null)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer",accessToken.Value);
                request.Headers.Add("lang", System.Threading.Thread.CurrentThread.CurrentUICulture.Name);
                request.Headers.Add("userId", myUserId.Value);
            }

            string accessTokenInSession = Convert.ToString(HttpContext.Current.Session["token"]);
            if (!string.IsNullOrEmpty(accessTokenInSession))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessTokenInSession);
                request.Headers.Add("lang", System.Threading.Thread.CurrentThread.CurrentUICulture.Name);
            }

            request.Headers.AcceptLanguage.Add(new StringWithQualityHeaderValue("en"));
            var response = _httpClient.SendAsync(request).Result;
            var apiResponse = new ApiResponse<T>(response.StatusCode);

            if(!response.IsSuccessStatusCode)
            {
                apiResponse.Message = response.Content.ReadAsStringAsync().Result;
            }
            else 
            {
                if(typeof(T)==typeof(byte[]))
                {
                    apiResponse.Model = (T)(object)response.Content.ReadAsByteArrayAsync().Result;
                }
                else
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    apiResponse.Model = JsonConvert.DeserializeObject<T>(result);
                }
            }
            return apiResponse;
        }

        private static ApiResponse<T> GetToken<T>(string uri, HttpMethod method, object input = null)
        {
            var request = new HttpRequestMessage(method, uri);
            if (input != null)
            {
                var keyValues = new List<KeyValuePair<string, string>>();

                var JSON = JsonConvert.SerializeObject(input);
                var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(JSON);
                foreach (var kv in dict)
                {
                    keyValues.Add(new KeyValuePair<string, string>(kv.Key, kv.Value));
                }

                keyValues.Add(new KeyValuePair<string, string>("grant_type", "password"));

                request.Content = new FormUrlEncodedContent(keyValues);
            }

            request.Headers.Add("lang", System.Threading.Thread.CurrentThread.CurrentUICulture.Name);
            request.Headers.AcceptLanguage.Add(new StringWithQualityHeaderValue("en"));

            var response = _httpClient.SendAsync(request).Result;
            var apiResponse = new ApiResponse<T>(response.StatusCode);

            if (!response.IsSuccessStatusCode)
            {
                apiResponse.Message = response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                if (typeof(T) == typeof(byte[]))
                {
                    apiResponse.Model = (T)(object)response.Content.ReadAsByteArrayAsync().Result;
                }
                else
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    apiResponse.Model = JsonConvert.DeserializeObject<T>(result);
                }
            }
            return apiResponse;
        }
    }
}
