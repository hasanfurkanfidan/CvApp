using Hff.CvApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.CvApp.DataAccess.Abstract
{
    public interface IAppUserRepository:IGenericRepository<AppUser>
    {
        /// <summary>
        ///   Eğer user var ise true yok ise false döner.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        bool CheckUser(string username, string password);
    }
}
