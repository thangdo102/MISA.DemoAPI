using MISA.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataAccessLayer.interfaces
{
    /// <summary>
    /// Interface của Employee Repository
    /// Author: DVTHANG(16/10/2020)
    /// </summary>
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {

        /// <summary>
        ///Kiểm tra thông tin nhân viên theo mã 
        ///Author: DVTHANG(15/10/2020)
        /// </summary>
        /// <param name="employeeCode">Mã nhân viên</param>
        /// <returns>true: có trùng, false: không</returns>
        bool checkEmployeeByCode(String employeeCode);

        /// <summary>
        ///check trùng số chứng minh thư
        ///Author: DVTHANG(17/10/2020)
        /// </summary>
        /// <param name="identityNumber">Số chứng minh thư</param>
        /// <returns>true: có, false: không</returns>
 /*       bool checkEmployeeByIdentityNumber(String identityNumber);*/

        /// <summary>
        ///check trùng số điện thoại 
        ///Author: DVTHANG(17/10/2020)
        /// </summary>
        /// <param name="phoneNumber">Số điện thoại</param>
        /// <returns>true: có, false: không</returns>
/*        bool checkEmployeeByPhoneNumber(String phoneNumber);*/
    }
}
