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
    getUrl() {
        return "/api/Employees";
    }
}


