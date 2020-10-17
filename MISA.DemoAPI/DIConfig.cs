using Microsoft.Extensions.DependencyInjection;
using MISA.BusinessLayer.Interfaces;
using MISA.BusinessLayer.Service;
using MISA.DataAccessLayer;
using MISA.DataAccessLayer.DatabaseAccess;
using MISA.DataAccessLayer.interfaces;
using MISA.DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.DemoAPI
{
    /// <summary>
    /// Hàm để config Các Interface sẽ sử dụng CLass nào mà cần dùng, ví dụ IEmployeeRepository sẽ config với EmployeeRepository để lấy data chứ ko phải DepartmentRepository 
    ///Author: DVTHANG(15/10/2020)
    ///</summary>
    public class DIConfig
    {
        public static void InjectionConfig(IServiceCollection services)
        {
            
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IDepartmentService, DepartmentService>();

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddScoped<IPositionRepository, PositionRepository>();
            services.AddScoped<IPositionService, PositionService>();

            services.AddScoped(typeof(IDatabaseContext<>), typeof(DatabaseContext<>));
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
        }
    }
}
