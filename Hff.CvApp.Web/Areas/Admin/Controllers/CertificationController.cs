using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hff.CvApp.Business.Abstract;
using Hff.CvApp.DTOs.Concrete.CertificationDtos;
using Hff.CvApp.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hff.CvApp.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class CertificationController : Controller
    {
        private readonly IGenericService<Certification> _genericService;
        private readonly IMapper _mapper;
        public CertificationController(IGenericService<Certification> genericService,IMapper mapper)
        {
            _genericService = genericService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            TempData["Active"] = "sertifikalarım";

            //var models =new List<CertificationListDto>();
            //var certifications = _genericService.GetAll();
            //foreach (var certification in certifications)
            //{
            //    var model = new CertificationListDto();
            //    model.Id = certification.Id;
            //    model.Description = certification.Description;
            //    models.Add(model);
            //}
            
            return View(_mapper.Map<List<CertificationListDto>>(_genericService.GetAll()));
        }
        public IActionResult Remove(int id)
        {          
            _genericService.Delete(_genericService.GetById(id));
            TempData["Message"] = "İşleminiz başarı ile gerçekleşti";
            return RedirectToAction("Index");
        }
        public IActionResult AddCertification()
        {
            TempData["Active"] = "sertifikalarım";
            var model = new CertificationAddDto();
            return View(model);
        }
        [HttpPost]
        public IActionResult AddCertification(CertificationAddDto model)
        {
            if (ModelState.IsValid)
            {
                _genericService.Insert(new Certification { Description = model.Description });
                TempData["Message"] = "İşleminiz başarı ile gerçekleşti";
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Update(int id)
        {
            var updatedEntity = _genericService.GetById(id);
            var model = new CertificationUpdateDto
            {
                Description = updatedEntity.Description,
                Id = updatedEntity.Id
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Update(CertificationUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                var updatedEntity = _genericService.GetById(model.Id);
                updatedEntity.Description = model.Description;
                _genericService.Update(updatedEntity);
                TempData["Message"] = "İşleminiz başarı ile gerçekleşti";
                return RedirectToAction("Index");
            }
            return View(model);
        }


    }
}
