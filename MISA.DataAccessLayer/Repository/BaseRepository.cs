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

        /// <summary>
        /// Xóa 1 đôi tượng
        /// AUTHOR: DVTHANG(15/10/2020)
        /// </summary>
        /// <param name="entityId">Id của đối tượng cần xóa</param>
        /// <returns></returns>
        public int Delete(Guid entityId)
        {
            return _databaseContext.Delete(entityId);
        }
        /// <summary>
        /// Lấy danh sách entity
        /// AUTHOR: DVTHANG(15/10/2020)
        /// </summary> 
        /// <returns></returns>
        public IEnumerable<T> Get()
        {
            return _databaseContext.Get();
        }
        /// <summary>
        /// Lấy enity by id
        /// AUTHOR: DVTHANG(15/10/2020)
        /// </summary> 
        /// <returns></returns>
        public T GetById(Guid entityId)
        {
            return _databaseContext.GetById(entityId);
        }

        /// <summary>
        /// Thêm mới một đối tượng
        /// AUTHOR: DVTHANG(15/10/2020)
        /// </summary>
        /// <param name="entity">đối tượng cần thêm mới</param>
        /// <returns></returns>
        public int Insert(T entity)
        {
            return _databaseContext.Insert(entity);
        }
        /// <summary>
        /// Update thông tin 1 đối tượng
        /// AUTHOR: DVTHANG(15/10/2020)
        /// </summary>
        /// <param name="entity">Đối tượng cần update</param>
        /// <returns></returns>
        public int update(T entity, Guid id)
        {
            return _databaseContext.update(entity, id);
        }
        #endregion
    }
}
