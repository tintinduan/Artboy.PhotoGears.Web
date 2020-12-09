using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;

namespace Artboy.PhotoGears.Web.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private SignInManager<IdentityUser> signInManager;
        public LogoutModel(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }
        public async Task OnGetAsync()
        {
            await signInManager.SignOutAsync();
        }
        
    }
}
