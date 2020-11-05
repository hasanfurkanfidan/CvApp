using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hff.CvApp.Business.Abstract;
using Hff.CvApp.DataAccess.Abstract;
using Hff.CvApp.DTOs.Concrete.SkillDto;
using Hff.CvApp.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hff.CvApp.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class SkillController : Controller
    {
        private readonly IGenericService<Skill> _genericService;
        private readonly IMapper _mapper;
        public SkillController(IGenericService<Skill>genericService,IMapper mapper)
        {
            _genericService = genericService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            TempData["active"] = "yetenek";
            return View(_mapper.Map<List<SkillListDto>>(_genericService.GetAll()));
        }
        public IActionResult Insert()
        {
            TempData["active"] = "yetenek";
            var model = new SkillAddDto();
            return View(model);
        }
        [HttpPost]
        public IActionResult Insert(SkillAddDto model)
        {
            if (ModelState.IsValid)
            {
                _genericService.Insert(new Skill { Description = model.Description });
                TempData["message"] = "İşlem başarıyla tamamlandı.";
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            var deletedEntity = _genericService.GetById(id);
            _genericService.Delete(deletedEntity);
            TempData["message"] = "İşlem başarıyla tamamlandı.";
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            TempData["active"] = "yetenek";
            var updatedEntity = _genericService.GetById(id);
            var model = new SkillUpdateDto();
            model.Description = updatedEntity.Description;
            model.Id = updatedEntity.Id;
            return View(model);
        }
        [HttpPost]
        public IActionResult Update(SkillUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                var updatedEntity = _genericService.GetById(model.Id);
                updatedEntity.Description = model.Description;
                _genericService.Update(updatedEntity);
                TempData["message"] = "İşlem başarıyla tamamlandı.";
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
