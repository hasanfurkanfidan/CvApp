using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hff.CvApp.Business.Abstract;
using Hff.CvApp.DataAccess.Abstract;
using Hff.CvApp.DTOs.Concrete.ExperienceDtos;
using Hff.CvApp.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hff.CvApp.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class ExperienceController : Controller
    {
        private readonly IGenericService<Experience> _genericService;
        private readonly IMapper _mapper;

        public ExperienceController(IGenericService<Experience> genericService,IMapper mapper)
        {
            _genericService = genericService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            TempData["active"] = "deneyim";
            return View(_mapper.Map<List<ExperienceListDto>>(_genericService.GetAll()));
        }
        public IActionResult Delete(int id)
        {
            var deletedEntity = _genericService.GetById(id);
            _genericService.Delete(deletedEntity);
            TempData["message"] = "İşlem başarıyla tamamlandı.";
            return RedirectToAction("Index");
        }
        public IActionResult Insert()
        {
            TempData["active"] = "deneyim";
            var model = new ExperienceAddDto();
            return View(model);
        }
        [HttpPost]
        public IActionResult Insert(ExperienceAddDto model)
        {
            if (ModelState.IsValid)
            {
                _genericService.Insert(new Experience
                {
                    Title = model.Title,
                    SubTitle = model.SubTitle,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    Description = model.Description
                });
                TempData["message"] = "İşlem başarıyla tamamlandı.";
                return RedirectToAction("Index");

            }
            return View(model);
        }
        public IActionResult Update(int id)
        {
            TempData["active"] = "deneyim";
            var updatedEntity = _genericService.GetById(id);
            var model = new ExperienceUpdateDto();
            model.Description = updatedEntity.Description;
            model.EndDate = updatedEntity.EndDate;
            model.Id = updatedEntity.Id;
            model.Title = updatedEntity.Title;
            model.SubTitle = updatedEntity.SubTitle;
            model.StartDate = updatedEntity.StartDate;
            return View(model);
        }
        [HttpPost]
        public IActionResult Update(ExperienceUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                var updatedEntity = _genericService.GetById(model.Id);
                updatedEntity.StartDate = model.StartDate;
                updatedEntity.EndDate = model.EndDate;
                updatedEntity.SubTitle = model.SubTitle;
                updatedEntity.Title = model.Title;
                updatedEntity.Description = model.Description;
                _genericService.Update(updatedEntity);
                TempData["message"] = "İşlem başarıyla tamamlandı.";
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
