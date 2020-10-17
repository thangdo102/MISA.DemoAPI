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
        /// <returns>true: có, false: không</returns>
        bool checkEmployeeByCode(String employeeCode);

    }
}
