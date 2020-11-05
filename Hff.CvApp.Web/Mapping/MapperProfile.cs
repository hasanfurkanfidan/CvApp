using AutoMapper;
using Hff.CvApp.DTOs.Concrete.AppUserDtos;
using Hff.CvApp.DTOs.Concrete.CertificationDtos;
using Hff.CvApp.DTOs.Concrete.EducationDtos;
using Hff.CvApp.DTOs.Concrete.ExperienceDtos;
using Hff.CvApp.DTOs.Concrete.SkillDto;
using Hff.CvApp.DTOs.Concrete.SocialMediaIconDtos;
using Hff.CvApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hff.CvApp.Web.Mapping
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<AppUser, AppUserListDto>();
            CreateMap<AppUserListDto, AppUser>();
            CreateMap<Certification, CertificationListDto>();
            CreateMap<CertificationListDto, Certification>();
            CreateMap<Skill, SkillListDto>();
            CreateMap<SkillListDto, Skill>();
            CreateMap<SocialMediaIcon, SocialMediaIconListDto>();
            CreateMap<SocialMediaIconListDto, SocialMediaIcon>();
            CreateMap<Experience, ExperienceListDto>();
            CreateMap<ExperienceListDto, Experience>();
            CreateMap<Education, EducationListDto>();
            CreateMap<EducationListDto, Education>();


        }
    }
}
