using MISA.Common.Models;
using MISA.DataAccessLayer.interfaces;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataAccessLayer.Repository
{

    /// <summary>
    /// Lớp Repository của Employee
    /// Author: DVTHANG(16/10/2020)
    /// </summary>
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IDatabaseContext<Employee> databaseContext) : base(databaseContext)
        {
        }


        /// <summary>
        /// Hàm check trùng Code
        /// Author: DVTHANG(21/10/2020)
        /// </summary>
        /// <param name="employeeCode">Employee Code</param>
        /// <returns></returns>
        public bool checkEmployeeByCode(string employeeCode)
        {
            var objectValue = _databaseContext.Get("PROC_CheckEmployeeCode", employeeCode);
            if (objectValue == null)
                return false;
            return true;
        }
    }
}
