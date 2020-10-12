using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using MISA.DemoAPI.Models;
using MySqlConnector;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.DemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeApi : ControllerBase
    {
        // GET: api/<EmployeeApi>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {

            var employees = new List<Employee>();
            //Lấy dữ liệu từ Database
            string connectionString = "User Id=nvmanh;Host=35.194.166.58;Password=12345678@Abc;Database=MISACukCuk_F09_DVTHANG;Character Set=utf8";
            //Khởi tạo kết nối:
            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);  //tạo kết nối
            //Khởi tạo đối tượng sql command để tương tác với database             
            MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();  //Tương tác với database
                                                                          //Khai báo kiểu truy vấn
            mySqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

            //Khai báo câu lệnh truy vấn
            /* mySqlCommand.CommandText = "SELECT * FROM Employee";*/
            mySqlCommand.CommandText = "PROC_GetEmployee";
            mySqlConnection.Open(); //mở cổng kết nối

            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();   //là đối tượng để xử lí việc đọc dữ liệu, reader là đọc lần lượt từng dòng một, hết dòng 1 sẽ xuống dòng 2
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
                    var property = employee.GetType().GetProperty(columnName);
                    //nếu có property tương ứng với tên cột thì gán dữ liệu tương ứng
                    if (property != null && columnValue != DBNull.Value)  //value và property phải có giá trị thì mới thực hiện gán
                    {
                        property.SetValue(employee, columnValue);
                    }
                }
                //thêm đối tượng khách hàng vừa khởi tạo vào list Employees
                employees.Add(employee);
            }
            mySqlConnection.Close();
            //1.Kết nối với Database
            //2.Thực thi command lấy dữ liệu

            return employees;
        }

        // GET api/<EmployeeApi>/5
        [HttpGet("{id}")]
        public string Get(Employee EmployeeCode)
        {
            //Lấy dữ liệu từ Database
            string connectionString = "User Id=nvmanh;Host=35.194.166.58;Password=12345678@Abc;Database=MISACukCuk_F09_DVTHANG;Character Set=utf8";
            //Khởi tạo kết nối:
            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);  //tạo kết nối
            //Khởi tạo đối tượng sql command để tương tác với database             
            MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();  //Tương tác với database
            //Khai báo kiểu truy vấn
            //mySqlCommand.CommandType = System.Data.CommandType.StoredProcedure;  //dùng để sử dụng Procedures

            //Khai báo câu lệnh truy vấn
            mySqlCommand.CommandText = "SELECT * FROM Employee";
            mySqlConnection.Open(); //mở cổng kết nối

            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();   //là đối tượng để xử lí việc đọc dữ liệu, reader là đọc lần lượt

            mySqlCommand.CommandText = "SELECT * FROM Employee where ";

            return "value";
        }

        // POST api/<EmployeeApi>
        [HttpPost]
        public void Post([FromBody] Employee employee)
        {
            //Lấy dữ liệu từ Database
            string connectionString = "User Id=nvmanh;Host=35.194.166.58;Password=12345678@Abc;Database=MISACukCuk_F09_DVTHANG;Character Set=utf8";
            //Khởi tạo kết nối:
            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);  //tạo kết nối
            //Khởi tạo đối tượng sql command để tương tác với database             
            MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();  //Tương tác với database
            //Khai báo kiểu truy vấn
            mySqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

            //Khai báo câu lệnh truy vấn
            mySqlCommand.CommandText = "PROC_InsertEmployee";
            mySqlConnection.Open(); //mở cổng kết nối

            var result = mySqlCommand.ExecuteNonQuery();  //Thực thi các câu lệnh sql giống như MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader(); nhưng ở đây sẽ trả về số lượng bản ghi bị thay đổi(thêm, sửa xóa)
        }

        // PUT api/<EmployeeApi>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeeApi>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
