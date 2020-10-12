using MISA.DemoAPI.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.DemoAPI.Models
{
    public class Employee
    {

        public Guid EmployeeId { get; set; }

        public String EmployeeCode { get; set; }

        public String EmployeeName { get; set; }

        public Gender Gender { get; set; }

        public String GenderName { get; set; }

        public String Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public String PhoneNumber { get; set; }

        public String IdentityNumber { get; set; }

        public DateTime IdentityDate { get; set; }

        public String IdentityPlace { get; set; }

        public Guid PositionId { get; set; }

        public Guid DepartmentId { get; set; }

        public String PositionName { get; set; }

        public String DepartmentName { get; set; }

        public String  TaxCode { get; set; }  

        public Double Salary { get; set; }

        public DateTime JoinDate { get; set; }

        public WorkStatus WorkStatus { get; set; }

        public String WorkStatusName { get; set; }

        public DateTime CreatedDate { get; set; }

        public String CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public String ModifiedBy { get; set; }
        
    }
}