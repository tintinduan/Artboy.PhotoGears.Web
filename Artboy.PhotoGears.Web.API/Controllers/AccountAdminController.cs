using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Artboy.PhotoGears.Models;
using Microsoft.AspNetCore.Authorization;

namespace Artboy.PhotoGears.Web.API.Controllers
{
    [ApiController]
    [Route("/api/admin/account")]
    [Authorize(Roles ="Admins")]
    public class AccountAdminController : ControllerBase
    {
        private UserManager<IdentityUser> userManager;
        
        public IEnumerable<IdentityUser> Users { get; set; }
        public IEnumerable<IdentityRole> Roles { get; set; }
        public List<Account> Accounts { get; set; }
        public AccountAdminController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetAccounts()
        {
            Users = userManager.Users;
            Accounts = new List<Account>();
            foreach(IdentityUser user in Users)
            {
                var roles = await userManager.GetRolesAsync(user);
                Account account = new Account();
                account.UserToAccount(user);
                if (roles != null && roles.Count > 0)
                {
                    foreach (var role in roles)
                    {
                        account.Roles.Add(role);
                    }
                }
                Accounts.Add(account);
            }
           if(Users == null || Users.Count()==0)
            {
                return NotFound();
            }
           else
            {
                return Ok(Accounts);
            }
        }

    }
}
