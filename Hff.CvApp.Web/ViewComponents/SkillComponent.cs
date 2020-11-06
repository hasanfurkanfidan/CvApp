using AutoMapper;
using Hff.CvApp.Business.Abstract;
using Hff.CvApp.DataAccess.Abstract;
using Hff.CvApp.DTOs.Concrete.SkillDto;
using Hff.CvApp.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hff.CvApp.Web.ViewComponents
{
    public class SkillComponent:ViewComponent
    {
        private readonly IGenericService<Skill> _genericService;
        private readonly IMapper _mapper;
        public SkillComponent(IGenericService<Skill> genericService,IMapper mapper)
        {
            _mapper = mapper;
            _genericService = genericService;
        }
        public IViewComponentResult Invoke()
        {
            return View(_mapper.Map<List<SkillListDto>>(_genericService.GetAll()));
        }
    }
}
