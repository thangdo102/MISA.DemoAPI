$(document).ready(function () {
    employJS = new EmployeeJS();
})


/**
 * Class EmployeeJS dùng để quản lý các function
 * Author: DVTHANG(23/09/2020)
 * */
class EmployeeJS extends BaseJS {
    constructor() {
        super();
    }

    getData() {
        this.Data = data;
    }

}

/**
 * Mảng dữ liệu employees
 * Author: DVTHANG(25/09/2020)
 * */
var data = [{
    EmployeeId: 1,
    EmployeeCode: "EM927362",
    FullName: "Nguyễn Văn A",
    Address: "Thái Nguyên",
    Phone: "029438333888",
    Email: "abc@gmail.com"
},
{
    EmployeeId: 2,
    EmployeeCode: "EP3820472",
    FullName: "Vũ Phương Thảo",
    Address: "Lâm Đồng",
    Phone: "093625423",
    Email: "thaobeo@gmail.com"
},
{
    EmployeeId: 3,
    EmployeeCode: "PO038233",
    FullName: "Lê Diệu Ly",
    Address: "Sơn la",
    Phone: "0932732442423",
    Email: "lile@gmail.com"
},
{
    EmployeeId: 4,
    EmployeeCode: "UI713487",
    FullName: "Nguyễn Trí Hiếu",
    Address: "Sapa",
    Phone: "0972623234243",
    Email: "hieuntm@gmail.com"
}


]

