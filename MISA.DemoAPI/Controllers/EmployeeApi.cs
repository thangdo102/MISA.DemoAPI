using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using MISA.BusinessLayer.Interfaces;
using MISA.BusinessLayer.Service;
using MISA.Common.Models;
using MISA.DataAccessLayer;
using MySqlConnector;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.DemoAPI.Controllers
{
    /// <summary>
    /// Api controller của Employee
    /// Author: DVTHANG(16/10/2020)
    /// </summary>
    [Route("api/employees")]
    public class EmployeeApi : BaseApi<Employee>
    {
        public EmployeeApi(IEmployeeService employeeService) : base(employeeService)
        {
        }

    }
}
