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
    /// Hàm để config xem Các Interface sẽ sử dụng CLass, ví dụ IEmployeeRepository sẽ config với EmployeeRepository để lấy data chứ ko phải DepartmentRepository 
    ///Author: DVTHANG(15/10/2020)
    ///</summary>
    public class DIConfig
    {

        public static void InjectionConfig(IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped(typeof(IDatabaseContext<>), typeof(IDatabaseContext<>));
            services.AddScoped(typeof(IBaseRepository<>), typeof(IBaseRepository<>));
            services.AddScoped(typeof(IBaseService<>), typeof(IBaseService<>));
        }
    }
}
