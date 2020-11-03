using Dapper.Contrib.Extensions;
using Hff.CvApp.DataAccess.Abstract;
using Hff.CvApp.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Hff.CvApp.DataAccess.Concrete.Dapper
{
    class DpGenericRepository<T> : IGenericRepository<T> where T : class, IEntity, new()
    {
        private readonly IDbConnection _connection;

        public DpGenericRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public void Delete(T entity)
        {
            _connection.Delete(entity);
        }

        public List<T> GetAll()
        {
            return _connection.GetAll<T>().ToList();
        }

        public T GetById(int id)
        {
            return _connection.Get<T>(id);
        }

        public void Insert(T Tentity)
        {
            _connection.Insert(Tentity);
        }

        public void Update(T entity)
        {
            _connection.Update(entity);
        }
    }
}
