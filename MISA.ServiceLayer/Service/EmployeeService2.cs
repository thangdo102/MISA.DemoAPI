using MISA.BusinessLayer.Interfaces;
using MISA.Common.Models;
using MISA.DataAccessLayer;
using MISA.DataAccessLayer.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.BusinessLayer.Service
{
    public class EmployeeService2 : IEmployeeService
    {
        IEmployeeRepository _employeeRepository;

        public EmployeeService2(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public bool checkEmployeeByCode(string employeeCode)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> Get()
        {
            throw new NotImplementedException();
        }

        public Employee GetById(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployeeById(Guid employeeId)
        {
            throw new NotImplementedException();
        }


        public int Insert(Employee employee)
        {
            //check trùng mã 
            var isExist = _employeeRepository.checkEmployeeByCode(employee.EmployeeCode);
            if (!isExist)
                return _employeeRepository.Insert(employee);
            else
                return 0;
        }

        public int update(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
