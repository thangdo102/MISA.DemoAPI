using MISA.Common.Models;
using MISA.DataAccessLayer.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataAccessLayer.Repository
{
    /// <summary>
    /// Lớp Repository của Department
    /// Author: DVTHANG(16/10/2020)
    /// </summary>
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(IDatabaseContext<Department> databaseContext) : base(databaseContext)
        {
        }
    }
}
