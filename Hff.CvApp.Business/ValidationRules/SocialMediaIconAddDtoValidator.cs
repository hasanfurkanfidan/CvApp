using FluentValidation;
using Hff.CvApp.DTOs.Concrete.SocialMediaIconDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.CvApp.Business.ValidationRules
{
   public class SocialMediaIconAddDtoValidator:AbstractValidator<SocialMediaIconAddDto>
    {
        public SocialMediaIconAddDtoValidator()
        {
            RuleFor(p => p.Icon).NotEmpty().WithMessage("İkon boş bırakılamaz");
            RuleFor(p => p.Link).NotEmpty().WithMessage("Link boş bırakılamaz");
            
        }
    }
}
