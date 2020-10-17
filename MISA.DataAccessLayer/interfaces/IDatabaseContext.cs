using MISA.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataAccessLayer.interfaces
{
    public interface IDatabaseContext<T>
    {
        IEnumerable<T> Get();
        T GetById(Guid entityId);
        object Get(String storeName, String code);
        int Insert(T entity);
        int update(T entity);
        int Delete(Guid entityId);
    }
}
