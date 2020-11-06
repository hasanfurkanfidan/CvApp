using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hff.CvApp.Business.Abstract;
using Hff.CvApp.DTOs.Concrete.SocialMediaIconDtos;
using Hff.CvApp.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hff.CvApp.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class SocialMediaIconController : Controller
    {
        private readonly ISocialMediaIconService _socialMediaIconService;
        private readonly IAppUserService _appUserService;

      

        private readonly IMapper _mapper;
        public SocialMediaIconController(ISocialMediaIconService socialMediaIconService,IMapper mapper,IAppUserService appUserService)
        {
            _socialMediaIconService = socialMediaIconService;
            _mapper = mapper;
            _appUserService = appUserService;
        }
        public IActionResult Index()
        {
            TempData["active"] = "sosyalmedya";
            var user = _appUserService.GetByUserName(User.Identity.Name);
            return View(_mapper.Map<List<SocialMediaIconListDto>>(_socialMediaIconService.GetAll()));
        }
        public IActionResult Insert()
        {
            TempData["active"] = "sosyalmedya";
            var model = new SocialMediaIconAddDto();
            return View(model);
        }
        [HttpPost]
        public IActionResult Insert(SocialMediaIconAddDto model)
        {
            if (ModelState.IsValid)
            {
                var user = _appUserService.GetByUserName(User.Identity.Name);
                _socialMediaIconService.Insert(new SocialMediaIcon
                {
                    AppUserId = user.Id,
                    Icon = model.Icon,
                    Link = model.Link,                   
                });
                TempData["message"] = "İşlem başarıyla gerçekleşti";
                return RedirectToAction("Index");
            }
            return View(model);
           
        }
        public IActionResult Delete(int id)
        {
            var deleted = _socialMediaIconService.GetById(id);
            _socialMediaIconService.Delete(deleted);
            TempData["message"] = "İşlem başarıyla gerçekleşti";
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            TempData["active"] = "sosyalmedya";
            var updatedEntity = _socialMediaIconService.GetById(id);
            var model = new SocialMediaIconUpdateDto();
            model.Link = updatedEntity.Link;
            model.Icon = updatedEntity.Icon;
            model.AppUserId = updatedEntity.AppUserId;
            model.Id = updatedEntity.Id;
            return View(model);
        }
        [HttpPost]
        public IActionResult Update(SocialMediaIconUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                var updatedEntity = _socialMediaIconService.GetById(model.Id);
                updatedEntity.AppUserId = model.AppUserId;
                updatedEntity.Icon = model.Icon;
                updatedEntity.Link = model.Link;
                _socialMediaIconService.Update(updatedEntity);
                TempData["message"] = "İşlem başarıyla gerçekleşti";
                return RedirectToAction("Index");
            }
            return View(model);
        }
        
    }
}
