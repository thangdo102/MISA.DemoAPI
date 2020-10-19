using MISA.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.Common.Models
{
    public class Employee
    {
        public Employee()
        {
            EmployeeId = Guid.NewGuid();
        }
        public Guid EmployeeId { get; set; }

        public String EmployeeCode { get; set; }

        public String EmployeeName { get; set; }

        public Gender Gender { get; set; }

        public string GenderName
        {
            get
            {
                switch (Gender)
                {
                    case Gender.Female:
                        return MISA.Common.Properties.Resources.Enum_Gender_Female;
                    case Gender.Male:
                        return MISA.Common.Properties.Resources.Enum_Gender_Male;
                    default:
                        return MISA.Common.Properties.Resources.Enum_Gender_Other;
                }
            }
        }

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

        public String TaxCode { get; set; }

        public Double Salary { get; set; }

        public DateTime JoinDate { get; set; }

        public WorkStatus WorkStatus { get; set; }

        public String WorkStatusName
        {
            get
            {
                switch (WorkStatus)
                {
                    case WorkStatus.Fresher:
                        return MISA.Common.Properties.Resources.Enum_WorkStatus_Fresher;
                    case WorkStatus.Working:
                        return MISA.Common.Properties.Resources.Enum_WorkStatus_Working;
                    case WorkStatus.TakeLeave:
                        return MISA.Common.Properties.Resources.Enum_WorkStatus_TakeLeave;
                    case WorkStatus.AtHome:
                        return MISA.Common.Properties.Resources.Enum_WorkStatus_AtHome;
                    case WorkStatus.Quit:
                        return MISA.Common.Properties.Resources.Enum_WorkStatus_Quit;
                    case WorkStatus.Offical:
                        return MISA.Common.Properties.Resources.Enum_WorkStatus_Offical;
                    case WorkStatus.Out:
                        return MISA.Common.Properties.Resources.Enum_WorkStatus_Out;
                    default:
                        return String.Empty;
                }
            }
        }

        public DateTime CreatedDate { get; set; }

        public String CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public String ModifiedBy { get; set; }

    }
}