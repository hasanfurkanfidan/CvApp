using FluentValidation;
using Hff.CvApp.DTOs.Concrete.SocialMediaIconDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.CvApp.Business.ValidationRules
{
   public class SocialMediaIconUpdateDtoValidator:AbstractValidator<SocialMediaIconUpdateDto>
    {
        public SocialMediaIconUpdateDtoValidator()
        {
            RuleFor(p => p.Id).InclusiveBetween(1, int.MaxValue).WithMessage("Id alanı boş geçilemez");
            RuleFor(p => p.Icon).NotEmpty().WithMessage("İkon boş bırakılamaz");
            RuleFor(p => p.Link).NotEmpty().WithMessage("Link boş bırakılamaz");
        }
    }
}
