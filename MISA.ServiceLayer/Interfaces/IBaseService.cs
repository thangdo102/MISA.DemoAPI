using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.BusinessLayer.Interfaces
{
   public interface IBaseService<T>
    {
        /// <summary>
        /// Lấy danh sách nhân viên
        /// AUTHOR: DVTHANG(15/10/2020)
        /// </summary> 
        /// <returns></returns>
        IEnumerable<T> Get();
        T GetById(Guid entityId);
        int Insert(T entity);
        int update(T entity);
        int Delete(Guid entityId);
    }
} 
