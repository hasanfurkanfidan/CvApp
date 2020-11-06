using Hff.CvApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.CvApp.Business.Abstract
{
   public interface ISocialMediaIconService:IGenericService<SocialMediaIcon>
    {
        List<SocialMediaIcon> GetByUserId(int userId);
    }
}
