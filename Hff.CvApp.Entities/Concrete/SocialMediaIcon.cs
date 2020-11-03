using Hff.CvApp.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.CvApp.Entities.Concrete
{
    [Dapper.Contrib.Extensions.Table("SocialMediaIcons")]
   public class SocialMediaIcon:IEntity
    {
        public int Id { get; set; }

        public string Link { get; set; }

        public string Icon { get; set; }

        public int AppUserId { get; set; }
    }
}
