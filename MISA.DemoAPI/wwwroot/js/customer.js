$(document).ready(function () {     //Hàm này sẽ chạy sau khi trang html được load hết dữ liệu, ví dụ trong ready có hàm loadData() nhưng khi chạy chương trình, 
    //trang sẽ load hết dữ liệu rồi mới đến hàm loadData()
    customerJS = new CustomerJS();
})

/**
 * Class CustomerJS dùng để quản lý các function
 * Author: DVTHANG(25/09/2020)
 * */
class CustomerJS extends BaseJS {
    constructor() {
        super();
    }

    getData() {
        this.Data = data;
    }

    initEventEmp() {
        super.initEventEmp();

    }
}

/**
 * Mảng dữ liệu Customer
 * Author: DVTHANG(25/09/2020)
 * */
var data = [
   /* {
        CustomerId: 1,
        CustomerCode: "SE06049",
        CustomerName: "Đỗ Văn Thắng",
        CompanyName: "MISA",
        DateOfBirth: new Date("1998/10/02"),
        Salary: "200000000",
        Address: "Hà Nội",
        Mobile: "0965281698",
        Email: "thangdvse06049@gmail.com",

    },
    {
        CustomerId: 2,
        CustomerCode: "SE903824",
        CustomerName: "Nguyễn Ngọc Hiếu",
        CompanyName: "MISA",
        DateOfBirth: new Date("1998/12/12"),
        Salary: "15000000",
        Address: "Sóc Sơn",
        Mobile: "0987333444",
        Email: "hieunn@gmail.com"

    },
    {
        CustomerId: 3,
        CustomerCode: "SE832423",
        CustomerName: "Lưu Phương Thảo",
        CompanyName: "MISA",
        DateOfBirth: new Date("1998/04/08"),
        Salary: 65770000,
        Address: "Ninh Bình",
        Mobile: "092333322222",
        Email: "thaolt@gmail.com"

    },
    {
        CustomerId: 4,
        CustomerCode: "SE5443234",
        CustomerName: "Lê Trọng Quân",
        CompanyName: "MISA2",
        DateOfBirth: new Date("1999/12/24"),
        Salary: "60000000",
        Address: "Hải Dương",
        Mobile: "09382723623",
        Email: "quanlt@gmail.com"

    },
    {
        CustomerId: 5,
        CustomerCode: "MF0482",
        CustomerName: "Trần Thị Quỳnh",
        CompanyName: "MISA3",
        DateOfBirth: new Date("1998/09/15"),
        Salary: "26000000",
        Address: "Phố Nỷ",
        Mobile: "09583772332",
        Email: "ttquynh@gmail.com"

    },
    {
        CustomerId: 6,
        CustomerCode: "MG3934",
        CustomerName: "Phạm Ngọc Sơn",
        CompanyName: "MISA4",
        DateOfBirth: new Date("1998/06/22"),
        Salary: "30000000",
        Address: "Sóc Sơn",
        Mobile: "0957777444",
        Email: "sonpn@gmail.com"

    },
    {
        CustomerId: 7,
        CustomerCode: "MS28347",
        CustomerName: "Trần Thị Lan Hương",
        CompanyName: "MISA3",
        DateOfBirth: new Date("1998/03/27"),
        Salary: "65000000",
        Address: "Sóc Sơn",
        Mobile: "09998478236",
        Email: "huongttl@gmail.com"

    }*/
]