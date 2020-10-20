using MISA.Common.Models;
using MISA.DataAccessLayer.interfaces;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MISA.DataAccessLayer.DatabaseAccess
{
    /// <summary>
    /// Hàm chứa các câu lệnh sql dùng cho MySQL
    /// Author: DVTHANG(15/10/2020)
    /// </summary>
    public class DatabaseContext<T> : IDisposable, IDatabaseContext<T>
    {
        #region declare
        MySqlConnection _sqlConnection;
        MySqlCommand _sqlCommand;
        readonly string _connectionString = "User Id=nvmanh;Host=35.194.166.58;Password=12345678@Abc;Database=MISACukCuk_F09_DVTHANG;Character Set=utf8";
        #endregion

        #region constructor
        public DatabaseContext()
        {
            _sqlConnection = new MySqlConnection(_connectionString);  //tạo kết nối
                                                                      //Khởi tạo đối tượng sql command để tương tác với database             
            _sqlCommand = _sqlConnection.CreateCommand();  //Tương tác với database
            _sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            _sqlConnection.Open(); //mở cổng kết nối
        }
        #endregion

        #region method
        public IEnumerable<T> Get()
        {
            var entities = new List<T>();
            var className = typeof(T).Name;  //
            //Khai báo câu lệnh truy vấn
            _sqlCommand.CommandText = $"PROC_Get{className}s";
            MySqlDataReader mySqlDataReader = _sqlCommand.ExecuteReader();   //là đối tượng để xử lí việc đọc dữ liệu, reader là đọc lần lượt từng dòng một, hết dòng 1 sẽ xuống dòng 2
            while (mySqlDataReader.Read())  //vòng lặp đọc từng hàng dữ liệu một lần
            {

                var entity = Activator.CreateInstance<T>();

                for (int i = 0; i < mySqlDataReader.FieldCount; i++)  //vòng lặp đọc từng ô trong hàng  
                {
                    //lấy tên của cột hiện tại
                    var columnName = mySqlDataReader.GetName(i);
                    //Lấy giá trị của cột hiện tại
                    var columnValue = mySqlDataReader.GetValue(i);
                    //Lấy ra property giống với tên cột được khai báo ở trên
                    var property = entity.GetType().GetProperty(columnName);  //giống với employee.EmployeeId = mySqlDataReader.getGuid(0);
                                                                              //nếu có property tương ứng với tên cột thì gán dữ liệu tương ứng
                    if (property != null && columnValue != DBNull.Value)  //value và property phải có giá trị thì mới thực hiện gán
                    {
                        property.SetValue(entity, columnValue);  //gán giá trị của column cho đối tượng employee
                    }
                }
                //thêm đối tượng khách hàng vừa khởi tạo vào list Employees
                entities.Add(entity);
            }
            //1.Kết nối với Database
            //2.Thực thi command lấy dữ liệu

            return entities;
        }

        /// <summary>
        /// Hàm lấy thông tin nhân viên theo Id
        /// Author: DVTHANG(14/10/2020)
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public T GetById(Guid employeeId)
        {
            //Khai báo câu lệnh truy vấn
            _sqlCommand.CommandText = "PROC_getEmployeeById";
            _sqlCommand.Parameters.AddWithValue("@EmployeeId", employeeId);
            MySqlDataReader mySqlDataReader = _sqlCommand.ExecuteReader();   //là đối tượng để xử lí việc đọc dữ liệu, reader là đọc lần lượt
            while (mySqlDataReader.Read())
            {
                var employee = Activator.CreateInstance<T>();
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
            return default;
        }


        /// <summary>
        ///  Hàm thêm mới dùng chung cho các entity
        /// Author: DVTHANG(14/10/2020)
        /// </summary>
        /// <param name="entity">đại diện cho các entity</param>
        /// <returns></returns>
        public int Insert(T entity)
        {
            var entityName = typeof(T).Name;
            _sqlCommand.Parameters.Clear();
            _sqlCommand.CommandText = $"PROC_Insert{entityName}";
            MySqlCommandBuilder.DeriveParameters(_sqlCommand);  //Lấy thông tin tham số từ procedure rồi thêm vào sqlCommand
            var parameters = _sqlCommand.Parameters;  //Lấy danh sách các param
            //var properties = typeof(T).GetProperties();

            foreach (MySqlParameter param in parameters)  //vòng lặp từng thằng param 
            {
                var paramName = param.ParameterName.Replace("@", string.Empty);  //Lấy ra paramName, bỏ chữ @ đi để lấy key
                var property = entity.GetType().GetProperty(paramName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);  //các param truyền vào trong procedure có thể viết hoa hoặc viết thường. Ví dụ: @departmentname
                if (property != null)
                    param.Value = property.GetValue(entity);  //lấy ra giá trị rồi gán cho param
            }
            var affectRows = _sqlCommand.ExecuteNonQuery();
            return affectRows;
        }


        /// <summary>
        /// Update entity
        /// AUTHOR: DVTHANG(13/10/2020)
        /// </summary>
        public int update(T entity)
        {
            var entityName = typeof(T).Name;
            _sqlCommand.Parameters.Clear();
            _sqlCommand.CommandText = $"Proc_Update{entityName}";
            MySqlCommandBuilder.DeriveParameters(_sqlCommand);
            var parameters = _sqlCommand.Parameters;
            foreach (MySqlParameter param in parameters)
            {
                var paramName = param.ParameterName.Replace("@", string.Empty);
                var property = entity.GetType().GetProperty(paramName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (property != null)
                    param.Value = property.GetValue(entity);
            }
            var result = _sqlCommand.ExecuteNonQuery();
            return result;
        }

        /// <summary>
        /// Xóa 1 nhân viên theo Id
        /// AUTHOR: DVTHANG(13/10/2020)
        /// </summary>
        /// <param name="employeeId"> id của nhân viên</param>
        // DELETE api/<EmployeeApi>/5
        public int Delete(Guid entityId)
        {
            var entityName = typeof(T).Name;
            _sqlCommand.Parameters.Clear();
            _sqlCommand.CommandText = $"PROC_Delete{entityName}ById";
            MySqlCommandBuilder.DeriveParameters(_sqlCommand);
            if (_sqlCommand.Parameters.Count > 0)
            {
                _sqlCommand.Parameters[0].Value = entityId;  //truyền param đầu tiên là EmployeeId cho entityId
            }
            var affectRows = _sqlCommand.ExecuteNonQuery();
            return affectRows;
        }

        /// <summary>
        /// Hàm kế thừa từ interface IDisposable, khi chạy xong thì sẽ tự động chạy vào hàm này, lợi dụng điều đó để cho nó thực hiện đóng connection luôn
        /// Author: DVTHANG(14/10/2020)
        /// </summary>
        public void Dispose()
        {
            _sqlConnection.Close();
        }

        /* public bool checkEmployeeByCode(string employeeCode)
         {
             //Khai báo câu lệnh truy vấn
             _sqlCommand.CommandText = "PROC_GetEmployeeByCode";
             _sqlCommand.Parameters.AddWithValue("@EmployeeCode", employeeCode);
             var mySQLDataValue = _sqlCommand.ExecuteScalar();
             if (mySQLDataValue == null)
                 return false;
             return true;
         }*/

        //check ko được trùng EmployeeCode
        public object Get(string storeName, string code)
        {
            _sqlCommand.Parameters.Clear();
            _sqlCommand.CommandText = storeName;
            _sqlCommand.Parameters.AddWithValue("@EmployeeCode", code);
            // Thực hiện đọc dữ liệu:
            return _sqlCommand.ExecuteScalar();
        }

        public object GetByIdentityCode(string storeName, string identityNumber)
        {
            _sqlCommand.Parameters.Clear();
            _sqlCommand.CommandText = storeName;
            _sqlCommand.Parameters.AddWithValue("@IdentityNumber", identityNumber);
            // Thực hiện đọc dữ liệu:
            return _sqlCommand.ExecuteScalar();
        }

        public object GetByPhoneNumber(string storeName, string phoneNumber)
        {
            _sqlCommand.Parameters.Clear();
            _sqlCommand.CommandText = storeName;
            _sqlCommand.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
            // Thực hiện đọc dữ liệu:
            return _sqlCommand.ExecuteScalar();
        }

        #endregion
    }
}

