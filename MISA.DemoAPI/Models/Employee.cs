using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.DemoAPI.Models
{
    public class Employee
    {
        public static List<Employee> employeeList = new List<Employee>()
        {
            new Employee()
            {
                EmployeeCode= "KH0001",EmployeeName = "Đỗ Văn Thắng", CompanyName = "MISAs", DateOfBirth = new DateTime(1998,02,10), Salary = 15000000, Address = "Hà Nội", Mobile = "0965281698", Email = "dvthang@gmail.com"
            },
            new Employee()
            {
                EmployeeCode= "KH0002",EmployeeName = "Lưu Phương Thảo", CompanyName = "MISA2",DateOfBirth = new DateTime(1998,3,14), Salary = 1900000, Address = "Ninh Bình", Mobile = "0967845678", Email = "thaolt@gmail.com"
            },
            new Employee()
            {
                EmployeeCode= "KH0003",EmployeeName = "Nguyễn Ngọc Hiếu", CompanyName = "MISA2",DateOfBirth = new DateTime(1998,12,12), Salary = 350000000, Address = "Hà Nội", Mobile = "0912345768", Email = "hieunnhieu@gmail.com"
            },
            new Employee()
            {
                EmployeeCode= "KH0004",EmployeeName = "Lê Diệu Ly", CompanyName = "MISA2",DateOfBirth = new DateTime(1998,6,7), Salary = 5600000, Address = "Sơn La", Mobile = "0987695665", Email = "lyld@gmail.com"
            },
            new Employee()
            {
                EmployeeCode= "KH0005",EmployeeName = "Vũ Phương Thảo", CompanyName = "MISA2",DateOfBirth = new DateTime(1998,5,2), Salary = 8000000, Address = "Lâm Đồng", Mobile = "0912314546", Email = "theovtp98@gmail.com"
            },
        };

        public String EmployeeCode { get; set; }

        public String EmployeeName { get; set; }

        public String CompanyName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Double Salary { get; set; }

        public String Address { get; set; }

        public String Mobile { get; set; }

        public String Email { get; set; }
    }
}