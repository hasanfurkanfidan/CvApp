﻿using FluentValidation;
using Hff.CvApp.DTOs.Concrete.EducationDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.CvApp.Business.ValidationRules
{
   public class EducationUpdateDtoValidator:AbstractValidator<EducationUpdateDto>
    {
        public EducationUpdateDtoValidator()
        {
            RuleFor(p => p.Id).InclusiveBetween(1, int.MaxValue).WithMessage("Id alanı boş geçilemez");

            RuleFor(p => p.Description).NotEmpty().WithMessage("Eğitim alanı boş geçilemez");

            RuleFor(p => p.StartDate).NotEmpty().WithMessage("Başlangıç tarihi boş bırakılamaz");

            RuleFor(p => p.SubTitle).NotEmpty().WithMessage("Alt başlık alanı boş bırakılamaz");

            RuleFor(p => p.Title).NotEmpty().WithMessage("Alt başlık boş bırakılamaz");
        }
    }
}
