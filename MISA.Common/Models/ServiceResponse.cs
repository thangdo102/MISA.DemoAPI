using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Models
{
    /// <summary>
    /// Class để thông báo lỗi
    /// Author: DVTHANG(16/10/2020)
    /// </summary>
    public class ServiceResponse
    {
        /// <summary>
        /// câu thông báo mà mình muốn
        /// </summary>
        public List<string> Msg { get; set; } = new List<string>();

        public bool Success { get; set; }


        //thuộc tính chứa dữ liệu trả về
        public object data { get; set; }
    }
}
