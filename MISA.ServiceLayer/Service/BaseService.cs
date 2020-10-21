using MISA.BusinessLayer.Interfaces;
using MISA.Common.Models;
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
        protected List<string> ValidateErrorResponseMsg = new List<string>(); 
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

        //khai báo virtual là chỉ đây là phương thức ảo
        protected virtual bool ValidateData(T entity)
        {
            return true;
        }

        public ServiceResponse Insert(T entity)
        {
            var serviceResponse = new ServiceResponse();
            //check trùng mã
            if (ValidateData(entity) == true)
            {
                serviceResponse.Success = true;
                serviceResponse.Msg.Add("Thành công");
                serviceResponse.data = _baseRepository.Insert(entity);
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Msg = ValidateErrorResponseMsg;
            }
            return serviceResponse;
            
        }

        public int update(T entity, Guid id)
        {
            return _baseRepository.update(entity, id);
        }
        #endregion
    }

}
