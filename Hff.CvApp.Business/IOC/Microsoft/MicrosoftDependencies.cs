using FluentValidation;
using Hff.CvApp.Business.Abstract;
using Hff.CvApp.Business.Concrete;
using Hff.CvApp.Business.ValidationRules;
using Hff.CvApp.DataAccess.Abstract;
using Hff.CvApp.DataAccess.Concrete.Dapper;
using Hff.CvApp.DTOs.Concrete.AppUserDtos;
using Hff.CvApp.DTOs.Concrete.CertificationDtos;
using Hff.CvApp.DTOs.Concrete.EducationDtos;
using Hff.CvApp.DTOs.Concrete.ExperienceDtos;
using Hff.CvApp.DTOs.Concrete.SkillDto;
using Hff.CvApp.DTOs.Concrete.SocialMediaIconDtos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Hff.CvApp.Business.IOC.Microsoft
{
   public static class MicrosoftDependencies
    {
        public static void AddCustomDependencies(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddTransient<IDbConnection>(con => new SqlConnection(configuration.GetConnectionString("connectionMsSql")));
            services.AddScoped<IAppUserRepository, DpAppUserRepository>();
            services.AddScoped<ISocialMediaIconRepository, DpSocialMediaRepository>();
            services.AddScoped<ISocialMediaIconService, SocialMediaIconManager>();
            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(DpGenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
            services.AddTransient<IValidator<AppUserUpdateDto>, AppUserUpdateDtoValidator>();
            services.AddTransient<IValidator<CertificationUpdateDto>, CertificationUpdateDtoValidator>();
            services.AddTransient<IValidator<AppUserPasswordDto>, AppUserPasswordDtoValidator>();
            services.AddTransient<IValidator<CertificationAddDto>, CertificationAddDtoValidator>();
            services.AddTransient<IValidator<SkillUpdateDto>, SkillUpdateDtoValidator>();
            services.AddTransient<IValidator<SkillAddDto>, SkillAddDtoValidator>();
            services.AddTransient<IValidator<ExperienceUpdateDto>, ExperienceUpdateDtoValidator>();
            services.AddTransient<IValidator<ExperienceAddDto>, ExperienceAddDtoValidator>();
            services.AddTransient<IValidator<EducationUpdateDto>, EducationUpdateDtoValidator>();
            services.AddTransient<IValidator<EducationAddDto>, EducationAddDtoValidator>();
            services.AddTransient<IValidator<SocialMediaIconUpdateDto>, SocialMediaIconUpdateDtoValidator>();
            services.AddTransient<IValidator<SocialMediaIconAddDto>, SocialMediaIconAddDtoValidator>();
        }
    }
}
