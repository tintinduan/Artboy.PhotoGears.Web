using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Artboy.PhotoGears.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Artboy.PhotoGears.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var controllerAssembly = Assembly.Load(new AssemblyName("Artboy.PhotoGears.Web.API"));
            services.AddMvc().AddApplicationPart(controllerAssembly).AddControllersAsServices();
            services.AddDbContext<PhotoGearsDbContext>(opts =>
            {
                opts.UseSqlServer(Configuration["ConnectionStrings:PhotoGearsConnection"]);
            });
            services.AddDbContext<AppIdentityDbContext>(opts =>
            {
                opts.UseSqlServer(Configuration["ConnectionStrings:IdentityConnection"]);
            });
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>();

            services.AddControllersWithViews();
            services.AddSession();
            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddScoped<IGenericRepository<Camera>, EFCameraRepository>();
            services.AddScoped<IGenericRepository<Lens>, EFLensRepository>();
            services.AddScoped<IGenericRepository<Accessory>, EFAccessoryRepository>();
            services.AddScoped<IGenericRepository<GearImage>, EFImageRepository>();
            services.AddScoped<IGenericRepository<Mount>, EFMountRepository>();
            services.AddMvc().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });
            services.Configure<IdentityOptions>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                opts.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            });
            services.AddAuthentication(opts =>
            {
                opts.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                opts.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(opts =>
            {
                opts.Events.DisableRedirectForPath(e => e.OnRedirectToLogin, "/api", StatusCodes.Status401Unauthorized);
                opts.Events.DisableRedirectForPath(e => e.OnRedirectToAccessDenied, "/api", StatusCodes.Status403Forbidden);
            }).AddJwtBearer(opts =>
            {
                opts.RequireHttpsMetadata = false;
                opts.SaveToken = true;
                opts.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.ASCII.GetBytes(Configuration["jwtSecret"])),
                    ValidateAudience = false,
                    ValidateIssuer = false
                };
                opts.Events = new JwtBearerEvents
                {
                    OnTokenValidated = async context =>
                    {
                        var usrmgr = context.HttpContext.RequestServices
                        .GetRequiredService<UserManager<IdentityUser>>();
                        var signinmgr = context.HttpContext.RequestServices
                        .GetRequiredService<SignInManager<IdentityUser>>();
                        string username = context.Principal.FindFirst(ClaimTypes.Name)?.Value;
                        IdentityUser idUser = await usrmgr.FindByNameAsync(username);
                        context.Principal = await signinmgr.CreateUserPrincipalAsync(idUser);
                    }
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
         

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/admin/{*catchall}", "/Admin/Index");
            });
            SeedData.EnsurePopulated(app);
            IdentitySeedData.CreateAdminAccount(app.ApplicationServices,Configuration);
        }
    }
}
