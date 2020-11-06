using AutoMapper;
using Hff.CvApp.Business.Abstract;
using Hff.CvApp.DTOs.Concrete.AppUserDtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Hff.CvApp.Web.ViewComponents
{
    public class AboutComponent:ViewComponent
    {
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;
        private readonly ISocialMediaIconService _socialMediaIconService;
        public AboutComponent(IAppUserService appUserService,IMapper mapper,ISocialMediaIconService socialMediaIconService)
        {
            _appUserService = appUserService;
            _mapper = mapper;
            _socialMediaIconService = socialMediaIconService;
        }
        public IViewComponentResult Invoke()
        {
            
            return View(_mapper.Map<AppUserListDto>(_appUserService.GetByUserName("hasanfurkanfidan")));
        }
    }
}
