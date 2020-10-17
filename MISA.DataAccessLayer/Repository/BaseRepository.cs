using MISA.DataAccessLayer.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataAccessLayer.Repository
{
    public class BaseRepository<T> : IBaseRepository<T>
    {
        protected IDatabaseContext<T> _databaseContext;

        public BaseRepository(IDatabaseContext<T> databaseContext)
        {
            _databaseContext = databaseContext;
        }

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

        public int update(T entity)
        {
            return _databaseContext.update(entity);
        }
    }
}
