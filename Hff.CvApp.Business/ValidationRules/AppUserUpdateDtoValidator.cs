using FluentValidation;
using Hff.CvApp.DTOs.Concrete.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.CvApp.Business.ValidationRules
{
   public class AppUserUpdateDtoValidator:AbstractValidator<AppUserUpdateDto>
    {
        public AppUserUpdateDtoValidator()
        {
            RuleFor(p => p.Id).InclusiveBetween(1, int.MaxValue).WithMessage("Id alanı boş geçilemez");
        }
    }
}
