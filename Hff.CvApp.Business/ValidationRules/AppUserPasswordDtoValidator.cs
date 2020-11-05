using FluentValidation;
using Hff.CvApp.DTOs.Concrete.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.CvApp.Business.ValidationRules
{
   public class AppUserPasswordDtoValidator:AbstractValidator<AppUserPasswordDto>
    {
        public AppUserPasswordDtoValidator()
        {
            RuleFor(p => p.Password).NotEmpty().WithMessage("Parola boş geçilemez");
            RuleFor(p => p.ConfirmPassword).NotEmpty().WithMessage("Parola boş geçilemez");
            RuleFor(p => p.ConfirmPassword).Equal(p => p.Password).WithMessage("Parolalar uyuşmuyor");
        }
    }
}
