using MISA.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.BusinessLayer.Interfaces
{
    public interface IEmployeeService : IBaseService<Employee>
    {
        /// <summary>
        ///check trùng mã nhân viên 
        ///Author: DVTHANG(15/10/2020)
        /// </summary>
        /// <param name="employeeCode">Mã nhân viên</param>
        /// <returns>true: có, false: không</returns>
        bool checkEmployeeByCode(String employeeCode);

    }
}
