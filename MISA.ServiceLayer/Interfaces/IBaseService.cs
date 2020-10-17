using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.BusinessLayer.Interfaces
{
   public interface IBaseService<T>
    {
        /// <summary>
        /// Lấy danh sách entity
        /// AUTHOR: DVTHANG(15/10/2020)
        /// </summary> 
        /// <returns></returns>
        IEnumerable<T> Get();

        /// <summary>
        /// lấy ra 1 đối tượng by Id
        /// AUTHOR: DVTHANG(15/10/2020)
        /// </summary>
        /// <param name="entityId">Id của đối tượng cần lấy </param>
        /// <returns></returns>
        T GetById(Guid entityId);

        /// <summary>
        /// Thêm mới một đối tượng
        /// AUTHOR: DVTHANG(15/10/2020)
        /// </summary>
        /// <param name="entity">đối tượng cần thêm mới</param>
        /// <returns></returns>
        int Insert(T entity);

        /// <summary>
        /// Update thông tin 1 đối tượng
        /// AUTHOR: DVTHANG(15/10/2020)
        /// </summary>
        /// <param name="entity">Đối tượng cần update</param>
        /// <returns></returns>
        int update(T entity);

        /// <summary>
        /// XÓa 1 đôi tượng
        /// AUTHOR: DVTHANG(15/10/2020)
        /// </summary>
        /// <param name="entityId">Id của đối tượng cần xóa</param>
        /// <returns></returns>
        int Delete(Guid entityId);
    }
} 
