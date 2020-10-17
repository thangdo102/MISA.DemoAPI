using MISA.Common.Models;
using MISA.DataAccessLayer.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataAccessLayer.Repository
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(IDatabaseContext<Department> databaseContext) : base(databaseContext)
        {

        }
    }
}
