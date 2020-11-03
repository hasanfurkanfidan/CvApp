using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.CvApp.Entities.Concrete
{
   public class BaseEntity
    {
        
        public int Id { get; set; }

        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
