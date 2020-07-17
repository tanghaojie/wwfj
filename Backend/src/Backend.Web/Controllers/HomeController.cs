using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Extensions;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;
using Abp.Runtime.Security;
using System.Linq;
using System;
using Abp.Runtime.Session;

namespace Backend.Web.Controllers
{
    public class HomeController : BackendControllerBase
    {
        public ActionResult Index()
        {
            if (!Request.GetDisplayUrl().EndsWith("/"))
            {
                return new RedirectResult(Request.GetDisplayUrl() + "/");
            }
            var x = AbpSession;
            var xx = typeof(Abp.Runtime.Session.ClaimsAbpSession);
            //PrincipalAccessor.Principal?.Claims.FirstOrDefault((Func<Claim, bool>)((Claim c) => c.Type == AbpClaimTypes.UserId));

            var userid = Request.HttpContext.User.Claims.FirstOrDefault((Func<Claim, bool>)((Claim c) => c.Type == AbpClaimTypes.UserId));
            
            //ClaimsPrincipal
            var u = x.UserId;
            return View();
        }

        public async Task<ActionResult> T()
        {
            var claims = new List<Claim>
            {
                new Claim(AbpClaimTypes.UserId, "123"),
                //new Claim(ClaimTypes.Name, "JT"),
                //new Claim("FullName", "Full"),
                //new Claim(ClaimTypes.Role, "Administrator"),
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                new AuthenticationProperties());
            return View();
        }

    }
}