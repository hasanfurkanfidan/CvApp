using Dapper;
using Hff.CvApp.DataAccess.Abstract;
using Hff.CvApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Hff.CvApp.DataAccess.Concrete.Dapper
{
   public class DpAppUserRepository:DpGenericRepository<AppUser>,IAppUserRepository
    {
        private readonly IDbConnection _dbConnection;
        public DpAppUserRepository(IDbConnection dbConnection):base(dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public bool CheckUser(string username, string password)
        {
            var user = _dbConnection.QueryFirstOrDefault<AppUser>("select * from AppUsers where username=@username and password=@password",new { username = username,password= password });
            if (user != null)
            {
                return true;
            }
            return false;
        }
    }
}
