using AutoMapper;
using Hff.CvApp.Business.Abstract;
using Hff.CvApp.DTOs.Concrete.EducationDtos;
using Hff.CvApp.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hff.CvApp.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class EducationController : Controller
    {
        private readonly IGenericService<Education> _genericService;
        private readonly IMapper _mapper;
        public EducationController(IGenericService<Education> genericService, IMapper mapper)
        {
            _genericService = genericService;
            _mapper = mapper;

        }
        public IActionResult Index()
        {
            TempData["active"] = "egitim";
            return View(_mapper.Map<List<EducationListDto>>(_genericService.GetAll()));
        }
        public IActionResult Insert()
        {
            TempData["active"] = "egitim";
            var model = new EducationAddDto();
            return View(model);
        }
      
        [HttpPost]
        public IActionResult Insert(EducationAddDto model)
        {
            if (ModelState.IsValid)
            {
                _genericService.Insert(new Education
                {
                    Description = model.Description,
                    Title = model.Title,
                    SubTitle = model.SubTitle,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate
                });
                TempData["message"] = "İşlem başarı ile tamamlandı";
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            var deletedEntity = _genericService.GetById(id);
            _genericService.Delete(deletedEntity);
            TempData["message"] = "İşlem başarı ile tamamlandı";
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            TempData["active"] = "egitim";
            var updatedEntity = _genericService.GetById(id);
            var model = new EducationUpdateDto
            {
                Description = updatedEntity.Description,
                EndDate = updatedEntity.EndDate,
                StartDate = updatedEntity.StartDate,
                SubTitle = updatedEntity.SubTitle,
                Id = updatedEntity.Id,
                Title = updatedEntity.Title

            };
            
            return View(model);
        }
        [HttpPost]
        public IActionResult Update(EducationUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                var updatedEntity = _genericService.GetById(model.Id);
                updatedEntity.StartDate = model.StartDate;
                updatedEntity.SubTitle = model.SubTitle;
                updatedEntity.Title = model.Title;
                updatedEntity.Description = model.Description;
                updatedEntity.EndDate = model.EndDate;
                _genericService.Update(updatedEntity);
                TempData["message"] = "İşlem başarı ile tamamlandı";
                return RedirectToAction("Index");

            }
            return View(model);
        }

    }
}
