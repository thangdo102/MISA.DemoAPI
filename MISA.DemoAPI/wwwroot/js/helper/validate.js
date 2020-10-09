
﻿/**
 * Object chứa các function validata chung
 * Author: DVTHANG(01/10/2020)
 * */
var validData = {
    /**
     * Hàm validate dữ liệu nhập vào, nếu ko nhập các trường bắt buộc,
     * sẽ ko Thêm được dữ liệu mới và input sẽ thêm CSS class require-error
     * Author: DVTHANG(10/01/2020)
     * */
    checkRequired: function () {
        var value = this.value;
        if (!value) {  //nếu input ko có value
            $(this).addClass('require-error');                          //thêm 1 class CSS từ trang dialog.css vào thẻ có id là txtEmployeeCode
            $(this).attr("title", "Bạn phải nhập thông tin này.");      //dùng để thêm thuộc tính(Attribute) cho thành phần.
                                                               //gặp return, sẽ dừng, k chạy dòng tiếp theo nữa
        } else {
            $(this).removeClass('require-error');
            $(this).removeAttr("title");
        }
    },

    /**
     * Validate Email
     * Author: DVTHANG(01/10/2020)
     * */
    validateEmail: function (email) {
        var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return re.test(email);
    }
}
