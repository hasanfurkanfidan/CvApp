using FluentValidation;
using Hff.CvApp.DTOs.Concrete.SkillDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.CvApp.Business.ValidationRules
{
   public class SkillAddDtoValidator:AbstractValidator<SkillAddDto>
    {
        public SkillAddDtoValidator()
        {
            RuleFor(p => p.Description).NotEmpty().WithMessage("Yetenek alanı boş geçilemez");
        }
    }
}
