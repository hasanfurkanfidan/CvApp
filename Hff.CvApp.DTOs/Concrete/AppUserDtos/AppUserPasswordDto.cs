using Hff.CvApp.DTOs.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.CvApp.DTOs.Concrete.AppUserDtos
{
   public class AppUserPasswordDto:IDTO
    {
        public int Id { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
