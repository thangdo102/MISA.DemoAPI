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
        /// Method của riêng đối tượng Employee
        /// Author: DVTHANG(16/10/2020)
        /// </summary>
        /// <param name="employeeCode">Code truyền vào để check của employee</param>
        /// <returns></returns>
        public bool checkEmployeeByCode(string employeeCode)
        {
            return _employeeRepository.checkEmployeeByCode(employeeCode);
        }
        #endregion
    }
}
