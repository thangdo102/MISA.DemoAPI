using MISA.Common.Models;
using MISA.DataAccessLayer.interfaces;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataAccessLayer.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IDatabaseContext<Employee> databaseContext) : base(databaseContext)
        {
        }

        public bool checkEmployeeByCode(string employeeCode)
        {
            var objectValue = _databaseContext.Get("PROC_GetEmployeeByCode2", employeeCode);
            if (objectValue == null)
                return false;
            else
                return true;
        }
    }
}
