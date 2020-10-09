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
            //Lấy dữ liệu từ Database
            string connectionString = "MISACukCuk_F09_DVTHANG";

            //Khởi tạo kết nối:
            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);  //tạo kết nối
            mySqlConnection.Open(); //mở cổng kết nối
            MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();  //Tương tác với database
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();   //là đối tượng để xử lí việc đọc dữ liệu, reader là đọc lần lượt
            while (mySqlDataReader.Read())
            {
                //Mỗi 1 vòng này sẽ tạo ra 1 employee
                var employee = new Employee();
                foreach (var item in mySqlDataReader)
                {

                }
            }

            //1.Kết nối với Database
            //2.Thực thi command lấy dữ liệu

            return Employee.employeeList;
        }

        // GET api/<EmployeeApi>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmployeeApi>
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
