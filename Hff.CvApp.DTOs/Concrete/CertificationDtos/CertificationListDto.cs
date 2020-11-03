using Hff.CvApp.DTOs.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.CvApp.DTOs.Concrete.CertificationDtos
{
   public class CertificationListDto:IDTO
    {
        public int Id { get; set; }

        public string Description { get; set; }
    }
}
