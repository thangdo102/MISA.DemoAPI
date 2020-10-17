using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataAccessLayer.interfaces
{
   public interface IBaseRepository<T>
    {
        IEnumerable<T> Get();
        T GetById(Guid entityId);
        int Insert(T entity);
        int update(T entity);
        int Delete(Guid entityId);
    }
}
