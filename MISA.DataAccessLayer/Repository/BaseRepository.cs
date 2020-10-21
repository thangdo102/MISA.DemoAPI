using MISA.DataAccessLayer.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataAccessLayer.Repository
{
    /// <summary>
    /// Hàm dùng chung của Repository
    /// Author: DVTHANG(16/10/2020)
    /// </summary>
    /// <typeparam name="T">Đối tượng tương ứng</typeparam>
    public class BaseRepository<T> : IBaseRepository<T>
    {
        #region declare
        public IDatabaseContext<T> _databaseContext;
        #endregion

        #region constructor
        public BaseRepository(IDatabaseContext<T> databaseContext)
        {
            _databaseContext = databaseContext;
        }
        #endregion

        #region method
        public int Delete(Guid entityId)
        {
            return _databaseContext.Delete(entityId);
        }

        public IEnumerable<T> Get()
        {
            return _databaseContext.Get();
        }

        public T GetById(Guid entityId)
        {
            return _databaseContext.GetById(entityId);
        }

        public int Insert(T entity)
        {
            return _databaseContext.Insert(entity);
        }

        public int update(T entity, Guid id)
        {
            return _databaseContext.update(entity, id);
        }
        #endregion
    }
}
