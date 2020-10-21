using MISA.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataAccessLayer.interfaces
{/// <summary>
 /// Interface chung của DatabaseContext
 /// Author: DVTHANG(16/10/2020)
 /// </summary>
 /// <typeparam name="T">Đối tượng chung</typeparam>
    public interface IDatabaseContext<T>
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
        /// Hàm lấy đối tượng tương ứng với procedures
        /// AUTHOR: DVTHANG(15/10/2020)
        /// </summary>
        /// <param name="storeName">Procedure để get đối tượng by Code</param>
        /// <param name="code">Code của đối tượng cần lấy</param>
        /// <returns></returns>
        object Get(String storeName, String code);

        /// <summary>
        /// Hàm lấy đối tượng tương ứng với procedures
        /// AUTHOR: DVTHANG(15/10/2020)
        /// </summary>
        /// <param name="storeName">Procedure để get đối tượng by Code</param>
        /// <param name="identityNumber">identityNumber của đối tượng cần lấy</param>
        /// <returns></returns>
        object GetByIdentityCode(String storeName, String identityNumber);

        /// <summary>
        /// Hàm lấy đối tượng tương ứng với procedures
        /// AUTHOR: DVTHANG(15/10/2020)
        /// </summary>
        /// <param name="storeName">Procedure để get đối tượng by Code</param>
        /// <param name="phoneNumber">Phone number của đối tượng cần lấy</param>
        /// <returns></returns>
        object GetByPhoneNumber(String storeName, String phoneNumber);

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
        int update(T entity, Guid id);

        /// <summary>
        /// Xóa 1 đôi tượng
        /// AUTHOR: DVTHANG(15/10/2020)
        /// </summary>
        /// <param name="entityId">Id của đối tượng cần xóa</param>
        /// <returns></returns>
        int Delete(Guid entityId);
    }
}
