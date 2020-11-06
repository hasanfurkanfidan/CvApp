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
   public class DpSocialMediaRepository:DpGenericRepository<SocialMediaIcon>,ISocialMediaIconRepository
    {
        private readonly IDbConnection _dbConnection;
        public DpSocialMediaRepository(IDbConnection dbConnection):base(dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public List<SocialMediaIcon> GetByUserId(int userId)
        {
            var list = _dbConnection.Query<SocialMediaIcon>("select * from socialmediaicons where appuserid = @appuserid", new { appuserid = userId });
            return list.ToList();
        }
    }
}
