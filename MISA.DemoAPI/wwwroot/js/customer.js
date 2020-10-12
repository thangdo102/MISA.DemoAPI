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

var data = [
 
]