using FluentValidation;
using Hff.CvApp.DTOs.Concrete.CertificationDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.CvApp.Business.ValidationRules
{
   public class CertificationUpdateDtoValidator:AbstractValidator<CertificationUpdateDto>
    {
        public CertificationUpdateDtoValidator()
        {
            RuleFor(p => p.Id).InclusiveBetween(1, int.MaxValue).WithMessage("Id alanı boş geçilemez");
            RuleFor(p => p.Description).NotEmpty().WithMessage("Sertifika alanı boş geçilemez");
        }
    }
}
