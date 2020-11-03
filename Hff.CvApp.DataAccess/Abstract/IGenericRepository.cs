using Hff.CvApp.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.CvApp.DataAccess.Abstract
{
   public interface IGenericRepository<T>where T:class,IEntity,new()
    {
        List<T> GetAll();

        T GetById(int id);

        void Insert(T Tentity);

        void Update(T entity);

        void Delete(T entity);
    }
}
