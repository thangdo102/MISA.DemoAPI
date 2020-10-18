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

        public bool checkEmployeeByCode(string employeeCode)
        {
            var objectValue = _databaseContext.Get("PROC_CheckEmployeeCode", employeeCode);
            if (objectValue == null)
                return false;
            return true;
        }

        public bool checkEmployeeByIdentityNumber(string identityNumber)
        {
            var objectValue = _databaseContext.GetByIdentityCode("PROC_CheckEmployeeIdentityNumber", identityNumber);
            if (objectValue == null)
                return false;
            return true;
        }

        public bool checkEmployeeByPhoneNumber(string phoneNumber)
        {
            var objectValue = _databaseContext.GetByPhoneNumber("PROC_CheckEmployeePhoneNumber", phoneNumber);
            if (objectValue == null)
                return false;
            return true;
        }
    }
}
