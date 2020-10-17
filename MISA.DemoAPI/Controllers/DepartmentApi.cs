using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MISA.BusinessLayer.Interfaces;
using MISA.Common.Models;
using MySqlConnector;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.DemoAPI.Controllers
{
    [Route("api/departments")]
    public class DepartmentApi : BaseApi<Department>
    {

        public DepartmentApi(IDepartmentService departmentService) : base(departmentService)
        {
        }
    }
}
