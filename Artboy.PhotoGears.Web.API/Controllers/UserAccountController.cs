using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;

namespace Artboy.PhotoGears.Web.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UserAccountController : ControllerBase
    {
        private SignInManager<IdentityUser> signInManager;
        private UserManager<IdentityUser> userManager;
        private IConfiguration configuration;
        public UserAccountController(SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.configuration = configuration;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Credentials credentials)
        {
            Microsoft.AspNetCore.Identity.SignInResult result
                = await signInManager.PasswordSignInAsync(credentials.UserName,
                        credentials.Password, false, false);
            if(result.Succeeded)
            {
                return Ok();
            }
            return Unauthorized();
        }
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Ok();
        }
        [HttpPost("token")]
        public async Task<IActionResult> Token([FromBody] Credentials credentials)
        {
            if (await CheckPassword(credentials))
            {
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                byte[] secret = Encoding.ASCII.GetBytes(configuration["jwtSecret"]);
                SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name,credentials.UserName)
                    }),
                    Expires = DateTime.UtcNow.AddHours(24),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(secret),
                        SecurityAlgorithms.HmacSha256Signature)
                };
                SecurityToken token = handler.CreateToken(descriptor);
                return Ok(new
                {
                    success = true,
                    token =handler.WriteToken(token)
                });
            }
            return Unauthorized();
        }
        private async Task<bool> CheckPassword(Credentials credentials)
        {
            IdentityUser user = await userManager.FindByNameAsync(credentials.UserName);
            if (user != null)
            {
                foreach (IPasswordValidator<IdentityUser> v in
                userManager.PasswordValidators)
                {
                    if ((await v.ValidateAsync(userManager, user,
                    credentials.Password)).Succeeded)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }

    public class Credentials
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
