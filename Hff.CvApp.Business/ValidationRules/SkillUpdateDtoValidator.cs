using FluentValidation;
using Hff.CvApp.DTOs.Concrete.SkillDto;
using Hff.CvApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.CvApp.Business.ValidationRules
{
   public class SkillUpdateDtoValidator:AbstractValidator<SkillUpdateDto>
    {
        public SkillUpdateDtoValidator()
        {
            RuleFor(p => p.Id).InclusiveBetween(1, int.MaxValue).WithMessage("Id alanı boş geçilemez");

            RuleFor(p => p.Description).NotEmpty().WithMessage("Yetenek alanı boş geçilemez");
            
        }
                    
    }
}
