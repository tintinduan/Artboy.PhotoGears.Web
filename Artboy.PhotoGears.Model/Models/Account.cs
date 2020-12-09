using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Artboy.PhotoGears.Models
{
    public class Account
    {
        [JsonPropertyName("User Id")]
        public string UserId { get; set; }
        [JsonPropertyName("User Name")]
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public Account()
        {
            Roles = new List<string>();
        }
        public void UserToAccount(IdentityUser user)
        {
            this.UserId = user.Id;
            this.UserName = user.UserName;
            this.Email = user.Email;
        }
    }
}
