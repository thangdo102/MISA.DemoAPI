using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MISA.Common.Models;
using MySqlConnector;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.DemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionApi : ControllerBase
    {
        // GET: api/<PositionApi>
        [HttpGet]
        public IEnumerable<Position> Get()
        {
            var positions = new List<Position>();
            //Lấy dữ liệu từ Database
            string connectionString = "User Id=nvmanh;Host=35.194.166.58;Password=12345678@Abc;Database=MISACukCuk_F09_DVTHANG;Character Set=utf8";
            //Khởi tạo kết nối:
            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);  //tạo kết nối
            //Khởi tạo đối tượng sql command để tương tác với database             
            MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();  //Tương tác với database
                                                                          //Khai báo kiểu truy vấn
            mySqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

            //Khai báo câu lệnh truy vấn
            mySqlCommand.CommandText = "PROC_getPosition";
            mySqlConnection.Open(); //mở cổng kết nối
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
            while (mySqlDataReader.Read())  //vòng lặp đọc từng hàng dữ liệu một lần
            {
                //Mỗi 1 vòng này sẽ tạo ra 1 employee
                var position = new Position();

                for (int i = 0; i < mySqlDataReader.FieldCount; i++)  //vòng lặp đọc từng ô trong hàng  
                {
                    //lấy tên của cột hiện tại
                    var columnName = mySqlDataReader.GetName(i);
                    //Lấy giá trị của cột hiện tại
                    var columnValue = mySqlDataReader.GetValue(i);
                    //Lấy ra property giống với tên cột được khai báo ở trên
                    var property = position.GetType().GetProperty(columnName);  //giống với employee.EmployeeId = mySqlDataReader.getGuid(0);
                    //nếu có property tương ứng với tên cột thì gán dữ liệu tương ứng
                    if (property != null && columnValue != DBNull.Value)  //value và property phải có giá trị thì mới thực hiện gán
                    {
                        property.SetValue(position, columnValue);  //gán giá trị của column cho đối tượng employee
                    }
                }
                //thêm đối tượng khách hàng vừa khởi tạo vào list Employees
                positions.Add(position);
            }
            mySqlConnection.Close();
            return positions;
        }

        // GET api/<PositionApi>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PositionApi>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PositionApi>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PositionApi>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
