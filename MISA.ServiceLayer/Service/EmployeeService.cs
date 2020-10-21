using MISA.BusinessLayer.Interfaces;
using MISA.Common.Models;
using MISA.DataAccessLayer;
using MISA.DataAccessLayer.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.BusinessLayer.Service
{
    /// <summary>
    /// Lớp service của Employee
    /// Author: DVTHANG(16/10/2020)
    /// </summary>
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        #region Declare
        IEmployeeRepository _employeeRepository;
        #endregion

        #region Constructor
        public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        #endregion

        #region method
        /// <summary>
        /// Các Method của riêng đối tượng Employee
        /// Author: DVTHANG(16/10/2020)
        /// </summary>
        /// <param name="employeeCode">Code truyền vào để check của employee</param>
        /// <returns></returns>
        public bool checkEmployeeByCode(string employeeCode)
        {
            return _employeeRepository.checkEmployeeByCode(employeeCode);
        }

        /// <summary>
        /// Hàm check trùng Code 
        /// </summary>
        /// <param name="entity">Đối tượng của Employee</param>
        /// <returns></returns>
        protected override bool ValidateData(Employee entity)
        {
            var isValid = true;
            //check trùng mã
            var isValidExistCode = checkEmployeeByCode(entity.EmployeeCode);
            if (isValidExistCode) //nếu bị trùng
            {
                isValid = false;
                ValidateErrorResponseMsg.Add("Mã bị trùng");
            }
            return isValid;  //return false là ko trùng, true là trùng
        }
        #endregion
    }
}
