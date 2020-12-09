using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Authentication.Cookies
{
    public static class CookieAuthenticationExtensions
    {
        public static void DisableRedirectForPath(this CookieAuthenticationEvents events,
            Expression<Func<CookieAuthenticationEvents,Func<RedirectContext<CookieAuthenticationOptions>,Task>>> expr,
            string path,int statuscode)
        {
            string propertyName = ((MemberExpression)expr.Body).Member.Name;
            var oldHandlder = expr.Compile().Invoke(events);

            Func<RedirectContext<CookieAuthenticationOptions>, Task> newHandler = context =>
             {
                 if (context.Request.Path.StartsWithSegments(path))
                 {
                     context.Response.StatusCode = statuscode;
                 }
                 else
                 {
                     oldHandlder(context);
                 }
                 return Task.CompletedTask;
             };
            typeof(CookieAuthenticationEvents).GetProperty(propertyName).SetValue(events, newHandler);
        }
    }
}
