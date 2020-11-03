using Hff.CvApp.Business.Abstract;
using Hff.CvApp.DataAccess.Abstract;
using Hff.CvApp.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.CvApp.Business.Concrete
{
    public class GenericManager<T> : IGenericService<T> where T : class, IEntity, new()
    {
        private readonly IGenericRepository<T> _genericRepository;

        public GenericManager(IGenericRepository<T> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public void Delete(T entity)
        {
            _genericRepository.Delete(entity);
        }

        public List<T> GetAll()
        {
            return _genericRepository.GetAll();
        }

        public T GetById(int id)
        {
            return _genericRepository.GetById(id);
        }

        public void Insert(T Tentity)
        {
            _genericRepository.Insert(Tentity);
        }

        public void Update(T entity)
        {
            _genericRepository.Update(entity);
        }
    }
}
