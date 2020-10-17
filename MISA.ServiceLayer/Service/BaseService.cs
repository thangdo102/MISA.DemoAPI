using MISA.BusinessLayer.Interfaces;
using MISA.DataAccessLayer.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.BusinessLayer.Service
{
    
    /// <summary>
    /// Hàm dùng chung của lớp Service
    /// Author: DVTHANG(15/10/2020)
    /// </summary>
    /// <typeparam name="T">Entity dùng chung</typeparam>
    public class BaseService<T> : IBaseService<T>
    {

        #region Declare
        IBaseRepository<T> _baseRepository;
        #endregion

        #region constructor
        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        #endregion

        #region method
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

        #endregion
    }

}
