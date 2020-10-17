using MISA.BusinessLayer.Interfaces;
using MISA.Common.Models;
using MISA.DataAccessLayer;
using MISA.DataAccessLayer.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.BusinessLayer.Service
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {

        IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public bool checkEmployeeByCode(string employeeCode)
        {
            return _employeeRepository.checkEmployeeByCode(employeeCode);
        }
    }
}
