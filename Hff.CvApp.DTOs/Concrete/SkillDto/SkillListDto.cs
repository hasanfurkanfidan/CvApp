using Hff.CvApp.DTOs.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.CvApp.DTOs.Concrete.SkillDto
{
   public class SkillListDto:IDTO
    {
        public int Id { get; set; }

        public string Description { get; set; }
    }
}
