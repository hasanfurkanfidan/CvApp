using AutoMapper;
using Hff.CvApp.Business.Abstract;
using Hff.CvApp.DTOs.Concrete.SocialMediaIconDtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hff.CvApp.Web.ViewComponents
{
    public class SocialMediaComponent:ViewComponent
    {
        private readonly ISocialMediaIconService _socialMediaIconService;
        private readonly IMapper _mapper;

        public SocialMediaComponent(ISocialMediaIconService socialMediaIconService,IMapper mapper)
        {
            _mapper = mapper;
            _socialMediaIconService = socialMediaIconService;
        }
        public  IViewComponentResult Invoke()
        {
            return View(_mapper.Map<List<SocialMediaIconListDto>>(_socialMediaIconService.GetAll()));
        }
    }
}
