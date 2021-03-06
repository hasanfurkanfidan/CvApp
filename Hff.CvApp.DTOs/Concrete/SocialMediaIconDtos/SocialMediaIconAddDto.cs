﻿using Hff.CvApp.DTOs.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.CvApp.DTOs.Concrete.SocialMediaIconDtos
{
   public class SocialMediaIconAddDto:IDTO
    {
        public string Link { get; set; }

        public string Icon { get; set; }

        public int AppUserId { get; set; }
    }
}
