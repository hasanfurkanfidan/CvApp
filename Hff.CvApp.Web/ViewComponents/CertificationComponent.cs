using AutoMapper;
using Hff.CvApp.Business.Abstract;
using Hff.CvApp.DataAccess.Abstract;
using Hff.CvApp.DTOs.Concrete.CertificationDtos;
using Hff.CvApp.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hff.CvApp.Web.ViewComponents
{
    public class CertificationComponent:ViewComponent
    {
        private readonly IGenericService<Certification> _genericService;
        private readonly IMapper _mapper;
        public CertificationComponent(IGenericService<Certification> genericService,IMapper mapper)
        {
            _genericService = genericService;
            _mapper = mapper;
        }
        public IViewComponentResult Invoke()
        {
            return View(_mapper.Map<List<CertificationListDto>>(_genericService.GetAll()));
        }
    }
}
