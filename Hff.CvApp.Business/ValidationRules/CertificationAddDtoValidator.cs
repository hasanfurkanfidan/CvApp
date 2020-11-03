using FluentValidation;
using Hff.CvApp.DTOs.Concrete.CertificationDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.CvApp.Business.ValidationRules
{
   public class CertificationAddDtoValidator:AbstractValidator<CertificationAddDto>
    {
        public CertificationAddDtoValidator()
        {
            RuleFor(p => p.Description).NotEmpty().WithMessage("Sertifika alanı boş geçilemez");
        }
    }
}
