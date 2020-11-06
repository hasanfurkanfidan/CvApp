using AutoMapper;
using Hff.CvApp.Business.Abstract;
using Hff.CvApp.DTOs.Concrete.AppUserDtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hff.CvApp.Web.ViewComponents
{
    public class NavbarComponent:ViewComponent
    {
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;
        public NavbarComponent(IMapper mapper,IAppUserService appUserService)
        {
            _mapper = mapper;
            _appUserService = appUserService;
        }
        public IViewComponentResult Invoke()
        {
            return View(_mapper.Map<AppUserListDto>(_appUserService.GetByUserName("hasanfurkanfidan")));
        }
    }
}
