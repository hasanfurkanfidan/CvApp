using AutoMapper;
using Hff.CvApp.Business.Abstract;
using Hff.CvApp.DTOs.Concrete.EducationDtos;
using Hff.CvApp.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hff.CvApp.Web.ViewComponents
{
    public class EducationComponent:ViewComponent
    {
        private readonly IGenericService<Education> _genericService;
        private readonly IMapper _mapper;
        public EducationComponent(IGenericService<Education> genericService,IMapper mapper)
        {
            _mapper = mapper;
            _genericService = genericService;
        }
        public IViewComponentResult Invoke()
        {

            return View(_mapper.Map<List<EducationListDto>>(_genericService.GetAll().OrderByDescending(p=>p.Id)));
        }
    }
}
