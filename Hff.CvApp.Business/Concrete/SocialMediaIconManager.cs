using Hff.CvApp.Business.Abstract;
using Hff.CvApp.DataAccess.Abstract;
using Hff.CvApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.CvApp.Business.Concrete
{
    public class SocialMediaIconManager : GenericManager<SocialMediaIcon>, ISocialMediaIconService
    {
        private readonly IGenericRepository<SocialMediaIcon> _genericRepository;
        private readonly ISocialMediaIconRepository _socialMediaIconRepository;
        public SocialMediaIconManager(IGenericRepository<SocialMediaIcon> genericRepository,ISocialMediaIconRepository socialMediaIconRepository):base(genericRepository)
        {
            _genericRepository = genericRepository;
            _socialMediaIconRepository = socialMediaIconRepository;
        }
        public List<SocialMediaIcon> GetByUserId(int userId)
        {
            return _socialMediaIconRepository.GetByUserId(userId);
        }
    }
}
