using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA.Common.Core.Model
{
    public class Token
    {
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }

        [JsonProperty(PropertyName = "expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty(PropertyName = ".issued")]
        public DateTime IssueDate { get; set; }

        [JsonProperty(PropertyName = ".expires")]
        public DateTime ExpiresAt { get; set; }

        public string Scope { get; set; }

        [JsonProperty(PropertyName = "token_type")]
        public string TokenType { get; set; }

        [JsonProperty(PropertyName = "userName")]
        public string UserName { get; set; }

        [JsonProperty(PropertyName = "rolesId")]
        public string RolesId { get; set; }

        [JsonProperty(PropertyName = "rolesName")]
        public string RolesName { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "userId")] 
        public string UserId { get; set; }
        public bool IsValidAndNotExpiring
        {
            get
            {
                return !String.IsNullOrEmpty(this.AccessToken) &&
               this.ExpiresAt > DateTime.UtcNow.AddSeconds(30);
            }
        }

        public ValidationMessage ValidationMessage { get; set; }
    }
}
