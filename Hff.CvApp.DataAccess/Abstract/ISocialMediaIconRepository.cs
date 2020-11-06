using Hff.CvApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.CvApp.DataAccess.Abstract
{
   public interface ISocialMediaIconRepository:IGenericRepository<SocialMediaIcon>
    {
       List<SocialMediaIcon> GetByUserId(int userId);
    }
}
