using Hff.CvApp.Business.Abstract;
using Hff.CvApp.DataAccess.Abstract;
using Hff.CvApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.CvApp.Business.Concrete
{
   public class AppUserManager : GenericManager<AppUser>, IAppUserService
    {
        private readonly IGenericRepository<AppUser> _genericRepository;
        private readonly IAppUserRepository _appUserRepository;
        public AppUserManager(IGenericRepository<AppUser> genericRepository,IAppUserRepository appUserRepository):base(genericRepository)
        {
            _appUserRepository = appUserRepository;
            _genericRepository = genericRepository;
        }
        public bool CheckUser(string userName, string password)
        {
            return _appUserRepository.CheckUser(userName, password);
        }
    }
}
