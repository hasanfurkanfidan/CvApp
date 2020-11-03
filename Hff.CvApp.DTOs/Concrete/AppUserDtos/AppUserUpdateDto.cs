using Hff.CvApp.DTOs.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.CvApp.DTOs.Concrete.AppUserDtos
{
   public class AppUserUpdateDto:IDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public int ImageUrl { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string ShortDescription { get; set; }
    }
}
