using MISA.BusinessLayer.Interfaces;
using MISA.DataAccessLayer.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.BusinessLayer.Service
{
   public class BaseService<T> : IBaseService<T>
    {
        IBaseRepository<T> _baseRepository;
        
        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
    }

        public int Delete(Guid entityId)
        {
            return _baseRepository.Delete(entityId);
        }

        public IEnumerable<T> Get()
        {
            return _baseRepository.Get();
        }

        public T GetById(Guid entityId)
        {
            return _baseRepository.GetById(entityId);
        }

        public int Insert(T entity)
        {
            return _baseRepository.Insert(entity);
        }

        public int update(T entity)
        {
            return _baseRepository.update(entity);
        }
    }
}
