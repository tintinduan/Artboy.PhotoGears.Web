using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Artboy.PhotoGears.Web.Pages.Roles
{
    public class CreateModel : AdminPageModel
    {
        public RoleManager<IdentityRole> RoleManager;
        public CreateModel(UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager)
        {
            RoleManager = roleManager;
        }
        [BindProperty]
        [Required]
        public string Name { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid) 
            {
                IdentityRole role = new IdentityRole { Name = Name };
                IdentityResult result = await RoleManager.CreateAsync(role);
                if (result.Succeeded) 
                {
                    return RedirectToPage("List");
                }
                foreach (IdentityError err in result.Errors) {
                ModelState.AddModelError("", err.Description);
                }
             }
                return Page();
        }
    }
}
