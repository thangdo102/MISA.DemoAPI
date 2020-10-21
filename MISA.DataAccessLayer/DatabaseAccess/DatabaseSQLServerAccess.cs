using MISA.Common.Models;
using MISA.DataAccessLayer.interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.DataAccessLayer
{
    /// <summary>
    /// Hàm chứa các câu lệnh sql dùng cho SQLServer
    /// Author: DVTHANG(15/10/2020)
    /// </summary>
    public class DatabaseSQLServerAccess : IDatabaseContext<Employee>, IDisposable
    {
        #region declare
        SqlConnection _sqlConnection;
        SqlCommand _sqlCommand;
        readonly string _connectionString = "User Id=nvmanh;Host=35.194.166.58;Password=12345678@Abc;Database=MISACukCuk_F09_DVTHANG;Character Set=utf8";
        #endregion

        #region constructor
        public DatabaseSQLServerAccess()
        {
            _sqlConnection = new SqlConnection(_connectionString);  //tạo kết nối
                                                                    //Khởi tạo đối tượng sql command để tương tác với database             
            _sqlCommand = _sqlConnection.CreateCommand();  //Tương tác với database
            _sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            _sqlConnection.Open(); //mở cổng kết nối
        }
        #endregion

        #region method
        public int Delete(Guid employeeId)
        {
            _sqlCommand.CommandText = "PROC_DeleteEmployeeById";
            //Gán giá trị đầu vào cho các tham số trong procedures:
            _sqlCommand.Parameters.AddWithValue("@EmployeeId", employeeId);
            var affectRows = _sqlCommand.ExecuteNonQuery();   //Trả về số dòng bị ảnh hưởng như thêm, sửa xóa được bao nhiêu dòng
            return affectRows;

        }

        public Employee GetById(Guid employeeId)
        {
            //Khai báo câu lệnh truy vấn
            _sqlCommand.CommandText = "PROC_getEmployeeById";
            _sqlCommand.Parameters.AddWithValue("@EmployeeId", employeeId);
            SqlDataReader mySqlDataReader = _sqlCommand.ExecuteReader();   //là đối tượng để xử lí việc đọc dữ liệu, reader là đọc lần lượt
            while (mySqlDataReader.Read())
            {
                var employee = new Employee();
                for (int i = 0; i < mySqlDataReader.FieldCount; i++)
                {
                    //lấy tên của cột hiện tại
                    var columnName = mySqlDataReader.GetName(i);
                    //Lấy giá trị của cột hiện tại
                    var columnValue = mySqlDataReader.GetValue(i);
                    //Lấy ra property giống với tên cột được khai báo ở trên
                    var property = employee.GetType().GetProperty(columnName);  //giống với employee.EmployeeId = mySqlDataReader.getGuid(0);
                    //nếu có property tương ứng với tên cột thì gán dữ liệu tương ứng
                    if (property != null && columnValue != DBNull.Value)  //value và property phải có giá trị thì mới thực hiện gán
                    {
                        property.SetValue(employee, columnValue);  //gán giá trị của column cho đối tượng employee
                    }
                }
                return employee;   //return trong while luôn vì mình chỉ muốn lấy về 1 employee
            }
            return null;
        }

        public IEnumerable<Employee> Get()
        {
            var employees = new List<Employee>();
            //Khai báo câu lệnh truy vấn
            /* mySqlCommand.CommandText = "SELECT * FROM Employee";*/
            _sqlCommand.CommandText = "PROC_GetEmployee";
            SqlDataReader mySqlDataReader = _sqlCommand.ExecuteReader();   //là đối tượng để xử lí việc đọc dữ liệu, reader là đọc lần lượt từng dòng một, hết dòng 1 sẽ xuống dòng 2
            while (mySqlDataReader.Read())  //vòng lặp đọc từng hàng dữ liệu một lần
            {
                //Mỗi 1 vòng này sẽ tạo ra 1 employee
                var employee = new Employee();

                for (int i = 0; i < mySqlDataReader.FieldCount; i++)  //vòng lặp đọc từng ô trong hàng  
                {
                    //lấy tên của cột hiện tại
                    var columnName = mySqlDataReader.GetName(i);
                    //Lấy giá trị của cột hiện tại
                    var columnValue = mySqlDataReader.GetValue(i);
                    //Lấy ra property giống với tên cột được khai báo ở trên
                    var property = employee.GetType().GetProperty(columnName);  //giống với employee.EmployeeId = mySqlDataReader.getGuid(0);
                    //nếu có property tương ứng với tên cột thì gán dữ liệu tương ứng
                    if (property != null && columnValue != DBNull.Value)  //value và property phải có giá trị thì mới thực hiện gán
                    {
                        property.SetValue(employee, columnValue);  //gán giá trị của column cho đối tượng employee
                    }
                }
                //thêm đối tượng khách hàng vừa khởi tạo vào list Employees
                employees.Add(employee);
            }
            //1.Kết nối với Database
            //2.Thực thi command lấy dữ liệu

            return employees;
        }

        public int Insert(Employee employee)
        {
            //dùng để sử dụng Procedures
            _sqlCommand.CommandText = "PROC_InsertEmployee";

            //Gán giá trị đầu vào cho các tham số trong procedures:
            _sqlCommand.Parameters.AddWithValue("@EmployeeId", Guid.NewGuid());
            _sqlCommand.Parameters.AddWithValue("@EmployeeCode", employee.EmployeeCode);
            _sqlCommand.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
            _sqlCommand.Parameters.AddWithValue("@Gender", employee.Gender);
            _sqlCommand.Parameters.AddWithValue("@Email", employee.Email);
            _sqlCommand.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);
            _sqlCommand.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
            _sqlCommand.Parameters.AddWithValue("@IdentityNumber", employee.IdentityNumber);
            _sqlCommand.Parameters.AddWithValue("@IdentityDate", employee.IdentityDate);
            _sqlCommand.Parameters.AddWithValue("@IdentityPlace", employee.IdentityPlace);
            _sqlCommand.Parameters.AddWithValue("@PositionId", employee.PositionId);
            _sqlCommand.Parameters.AddWithValue("@DepartmentId", employee.DepartmentId);
            _sqlCommand.Parameters.AddWithValue("@TaxCode", employee.TaxCode);
            _sqlCommand.Parameters.AddWithValue("@Salary", employee.Salary);
            _sqlCommand.Parameters.AddWithValue("@JoinDate", employee.JoinDate);
            _sqlCommand.Parameters.AddWithValue("@WorkStatus", employee.WorkStatus);

            var affectRows = _sqlCommand.ExecuteNonQuery();   //Trả về số dòng bị ảnh hưởng như thêm, sửa xóa được bao nhiêu dòng

            return affectRows;
        }

        public int update(Employee employee, Guid id)
        {
            _sqlCommand.CommandText = "PROC_UpdateEmployee";

            //Gán giá trị đầu vào cho các tham số trong procedures:
            _sqlCommand.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
            _sqlCommand.Parameters.AddWithValue("@EmployeeCode", employee.EmployeeCode);
            _sqlCommand.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
            _sqlCommand.Parameters.AddWithValue("@Gender", employee.Gender);
            _sqlCommand.Parameters.AddWithValue("@Email", employee.Email);
            _sqlCommand.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);
            _sqlCommand.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
            _sqlCommand.Parameters.AddWithValue("@IdentityNumber", employee.IdentityNumber);
            _sqlCommand.Parameters.AddWithValue("@IdentityDate", employee.IdentityDate);
            _sqlCommand.Parameters.AddWithValue("@IdentityPlace", employee.IdentityPlace);
            _sqlCommand.Parameters.AddWithValue("@PositionId", employee.PositionId);
            _sqlCommand.Parameters.AddWithValue("@DepartmentId", employee.DepartmentId);
            _sqlCommand.Parameters.AddWithValue("@TaxCode", employee.TaxCode);
            _sqlCommand.Parameters.AddWithValue("@Salary", employee.Salary);
            _sqlCommand.Parameters.AddWithValue("@JoinDate", employee.JoinDate);
            _sqlCommand.Parameters.AddWithValue("@WorkStatus", employee.WorkStatus);
            //mySqlCommand.Parameters.AddWithValue("@CreatedDate", employee.CreatedDate);


            var affectRows = _sqlCommand.ExecuteNonQuery();   //Trả về số dòng bị ảnh hưởng như thêm, sửa xóa được bao nhiêu dòng

            return affectRows;
        }

        public void Dispose()
        {
            _sqlConnection.Close();
        }

        public bool checkEmployeeByCode(string employeeCode)
        {
            throw new NotImplementedException();
        }

        public object Get(string storeName, string code)
        {
            throw new NotImplementedException();
        }

        public object GetByIdentityCode(string storeName, string identityNumber)
        {
            throw new NotImplementedException();
        }

        public object GetByPhoneNumber(string storeName, string phoneNumber)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
