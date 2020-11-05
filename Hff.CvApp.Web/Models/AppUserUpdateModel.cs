using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hff.CvApp.Web.Models
{
    public class AppUserUpdateModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Ad alanı gereklidir.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Soyad alanı gereklidir.")]

        public string LastName { get; set; }
        [Required(ErrorMessage = "Adres alanı gereklidir.")]

        public string Adress { get; set; }
        [Required(ErrorMessage = "Email alanı gereklidir.")]

        public string Email { get; set; }
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Telefon Numarası alanı gereklidir.")]

        public string PhoneNumber { get; set; }

        public IFormFile FormFile { get; set; }
        [Required(ErrorMessage = "Kısa açıklama alanı gereklidir.")]

        public string ShortDescription { get; set; }
    }
}
