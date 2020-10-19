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

        public bool checkEmployeeByIdentityNumber(string identityNumber)
        {
            return _employeeRepository.checkEmployeeByIdentityNumber(identityNumber);
        }

        public bool checkEmployeeByPhoneNumber(string phoneNumber)
        {
            return _employeeRepository.checkEmployeeByPhoneNumber(phoneNumber);
        }

        protected override bool ValidateData(Employee entity)
        {
            var isValid = true;
            //check trùng mã
           var isValidExistCode =  checkEmployeeByCode(entity.EmployeeCode);
            if (isValidExistCode) //nếu bị trùng
            {
                isValid = false;
                ValidateErrorResponseMsg.Add("Mã bị trùng");
            }

            //check trùng số cmt, bên dưới sẽ check các kiểu giống check mã ở phía trên.
            //Cứ mỗi lần mã, số điện thoại hay số CMT bị trùng, thì lại add 1 string vào chuỗi string chứa các lỗi để hiển thị ra view cho người dùng xem
            var isValidExistIdentity = checkEmployeeByIdentityNumber(entity.IdentityNumber);
            if (isValidExistIdentity)
            {
                isValid = false;
                ValidateErrorResponseMsg.Add("số CMT bị trùng");
            }

            //check trùng số điện thoại
            var isValidExistPhoneNumber = checkEmployeeByPhoneNumber(entity.PhoneNumber);
            if (isValidExistPhoneNumber)
            {
                isValid = false;
                ValidateErrorResponseMsg.Add("Số điện thoại bị trùng");
            }

            return isValid;  //return false là ko trùng, true là trùng
        }
        #endregion
    }
}
