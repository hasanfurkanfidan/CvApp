using AutoMapper;
using Hff.CvApp.Business.Abstract;
using Hff.CvApp.DataAccess.Abstract;
using Hff.CvApp.DTOs.Concrete.ExperienceDtos;
using Hff.CvApp.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hff.CvApp.Web.ViewComponents
{
    public class ExperienceComponent:ViewComponent
    {
        private readonly IGenericService<Experience> _genericService;
        private readonly IMapper _mapper;
        public ExperienceComponent(IGenericService<Experience> genericService,IMapper mapper)
        {
            _mapper = mapper;
            _genericService = genericService;
        }
        public IViewComponentResult Invoke()
        {
            return View(_mapper.Map<List<ExperienceListDto>>(_genericService.GetAll().OrderByDescending(p => p.Id)));
        }
    }
}
