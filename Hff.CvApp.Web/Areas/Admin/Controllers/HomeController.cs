using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Hff.CvApp.Business.Abstract;
using Hff.CvApp.DTOs.Concrete.AppUserDtos;
using Hff.CvApp.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hff.CvApp.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class HomeController : Controller
    {
        private readonly IAppUserService _appUserService;

        public HomeController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        public IActionResult Index()
        {
            var user = _appUserService.GetByUserName(User.Identity.Name);
            TempData["Active"] = "bilgilerim";
            var model = new AppUserUpdateModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Adress = user.Adress,
                Id = user.Id,
                ShortDescription = user.ShortDescription,
                Email = user.Email,
                ImageUrl = user.ImageUrl,
                PhoneNumber = user.PhoneNumber
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(AppUserUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                var updatedUser = _appUserService.GetById(model.Id);
                
                if (model.FormFile!=null)
                {
                    var imageName = Guid.NewGuid() + Path.GetExtension(model.FormFile.FileName);
                    var path = Directory.GetCurrentDirectory() + "/wwwroot/img/" + imageName;
                    var stream = new FileStream(path,FileMode.Create);
                    model.FormFile.CopyTo(stream);
                    updatedUser.ImageUrl = imageName; 
                }
                updatedUser.FirstName = model.FirstName;
                updatedUser.LastName = model.LastName;
                updatedUser.PhoneNumber = model.PhoneNumber;
                updatedUser.ShortDescription = model.ShortDescription;
                updatedUser.Adress = model.Adress;
                updatedUser.Email = model.Email;
                _appUserService.Update(updatedUser);
                TempData["Message"] = "İşleminiz başarı ile gerçekleşti";
                return RedirectToAction("Index");              
            }
            var user = _appUserService.GetById(model.Id);
            model.ImageUrl = user.ImageUrl;
            return View(model);
        }
        public IActionResult ChangePassword()
        {
            TempData["Active"] = "sifre";
            var user = _appUserService.GetByUserName(User.Identity.Name);
            return View(
                new AppUserPasswordDto
                {
                    Id = user.Id,  
                }
                );
        }
        [HttpPost]
        public IActionResult ChangePassword(AppUserPasswordDto model)
        {
            TempData["Active"] = "sifre";

            if (ModelState.IsValid)
            {
                var updatedUser = _appUserService.GetById(model.Id);
                updatedUser.Password = model.Password;
                _appUserService.Update(updatedUser);
                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                TempData["Message"] = "İşleminiz başarı ile gerçekleşti";
            }
            return View(model);
        }
    }
}
