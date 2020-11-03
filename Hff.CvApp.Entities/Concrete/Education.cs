using Hff.CvApp.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.CvApp.Entities.Concrete
{
    [Dapper.Contrib.Extensions.Table("Educations")]
   public class Education:BaseEntity,IEntity
    {
    }
}
