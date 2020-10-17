using MISA.BusinessLayer.Interfaces;
using MISA.Common.Models;
using MISA.DataAccessLayer.interfaces;
using MISA.DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.BusinessLayer.Service
{
    public class DepartmentService : BaseService<Department>, IDepartmentService
    {
        IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository) : base(departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
    }
}
