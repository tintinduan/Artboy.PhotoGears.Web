using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;

namespace Artboy.PhotoGears.Web.Pages.Account
{
    public class DetailsModel : PageModel
    {
        private UserManager<IdentityUser> userManager;
        public IdentityUser IdentityUser { get; set; }
        public DetailsModel(UserManager<IdentityUser> userMgr)
        {
            userManager = userMgr;
        }
        public async Task OnGetAsync()
        {
            if(User.Identity.IsAuthenticated)
            {
                IdentityUser = await userManager.FindByNameAsync(User.Identity.Name);
            }
        }
    }
}
