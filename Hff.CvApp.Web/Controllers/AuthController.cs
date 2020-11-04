using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Hff.CvApp.Business.Abstract;
using Hff.CvApp.DataAccess.Abstract;
using Hff.CvApp.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Hff.CvApp.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAppUserService _appUserService;

        public AuthController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }
        public IActionResult Login()
        {
            return View(new AppUserLoginModel());
        }
        [HttpPost]
        public async Task< IActionResult> Login(AppUserLoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (_appUserService.CheckUser(model.Username,model.Password))
                {
                   await CookieConfiguration(model.Username,model.Password,model.RememberMe);
                    //giriş başarılı
                    return RedirectToAction("Index", "Home", new { @area = "Admin" });
                }
                //giriş başarısız
                ModelState.AddModelError("", "Kullanıcı adı yada parola hatalı.");
            }
            return View(model);
        }

        private async Task CookieConfiguration(string username, string password, bool rememberMe)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,username),
                new Claim(ClaimTypes.Role,"Admin")

            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = rememberMe
            };
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
        }
    }
}
