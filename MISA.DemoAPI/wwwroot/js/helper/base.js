$(document).ready(function () {
    //load dữ liệu

})
/**
 * Class EmployeeJS dùng để quản lý các function
 * Author: DVTHANG(23/09/2020)
 * */

class BaseJS {

    /**
     * Constructor của class
     * Author: DVTHANG(23/09/2020)
     * */
    constructor() {
        this.loadData();
        this.loadDepartment();
        this.loadPosition();
        this.initEventEmp();
        this.onHiddenDialog();
        this.onHiddenDialogConfirm();
        this.onHiddenDialogNoti();
        this.getUrl();
        var FormMode;
        this.getLastedEmployeeCode();
    }


    /**
     * Hàm lấy Url cho employee
     * Author: DVTHANG(20/10/2020)
     * */
    getUrl() {

    }

    /**
    * Hàm load dữ liệu từ mảng employees lên bảng
    *  Author: DVTHANG(23/09/2020)
    * */
    loadData() {
        debugger
        //Lấy dữ liệu trên server thông qua lời gọi tới api service:
        $.ajax({
            url: this.getUrl(),
            method: "GET",
            data: "",
            contentType: "application/json",
            dataType: ""

        }).done(function (response) {
            debugger
            var fields = $('table#tbListData thead th');  //lấy tất cả các th  
            $('#tbListData tbody').empty();
            $.each(response, function (index, obj) {   //duyệt từng phần tử của mảng các đối tượng 
                var tr = $(`<tr></tr>`);   //tạo ra <tr>

                $.each(fields, function (index, field) {    //duyệt từng phần tử th
                    var fieldName = $(field).attr(`fieldName`);   //lấy giá trị của thuộc tính fieldName rồi lưu vào biến fieldName
                    var value = obj[fieldName];
                    var keyId = $("#tbListData").attr('keyId');
                    //format cho các cột money
                    var formatSalary = $(field).attr(`formatSalary`);
                    var formatDate = $(field).attr(`formatDate`);
                    if (formatSalary == 'validateSalary') {
                        var value = (obj[fieldName]).toString().replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,");
                    } else if (formatDate == "date" && value) {
                        value = new Date(value);
                        var value = commonJS.formatDate(value);
                    }
                    else {
                        var value = (obj[fieldName] || (" "));  // obj[fieldName] giống với customer.[CustomerCode], ||(" ") là nếu bị sai trường, sẽ hiển thị khoảng trắng thay vì hiển thị underfine
                    }
                    var td = $(`<td>` + value + `</td>`);   //tạo ra các td
                    //căn chỉnh trái phải giữa cho number, string, date, money
                    var format = $(field).attr(`format`);
                    if (format == "validateString") {
                        td.addClass('validateString');
                    } else if (format == "validateNumber") {
                        td.addClass('validateNumber');
                    } else if (format == "validateDate") {
                        td.addClass('validateDate');
                    }
                    $(tr).data('keyId', obj[keyId]); // lưu Employee.EmployeeId vào attribute là keyId
                    $(tr).append(td); //append từng thằng td vào tr
                })
                $('#tbListData tbody').append(tr);
            })
        }).fail(function response() {
        })
    }

    /**
 * Hàm dùng chung để lấy ra id của row được chọn
 * Author: DVTHANG(02/10/2020)
 * */
    getRecordIdSelected() {
        //Lấy id của bản ghi được chọn
        var rowId = null;
        var recordSelected = $('#tbListData tbody .row-selected');
        //Lấy dữ liệu chi tiết của bản ghi đó
        debugger
        if (recordSelected.length > 0) {
            rowId = $(recordSelected).data("keyId");
        }
        return rowId;
    }


    /**
     * Hàm load danh sách department trong dialog
     * Author: DVTHANG(13/10/2020)
     * */
    loadDepartment() {
        $.ajax({
            url: "/api/departments",
            method: "GET",
            data: "",
            contentType: "application/json",
            dataType: ""
        }).done(function (response) {
            $.each(response, function (i, department) {
                $("#departmentName").append($('<option></option>').val(department.departmentId).text(department.departmentName));
            })
        }).fail(function (response) {
        })
    }

    /**
     * Hàm load danh sách Position trong dialog
     * Author: DVTHANG(13/10/2020)
     * */
    loadPosition() {
        $.ajax({
            url: "/api/positions",
            method: "GET",
            data: "",
            contentType: "application/json",
            dataType: ""
        }).done(function (response) {
            $.each(response, function (i, position) {
                $("#positionName").append($('<option></option>').val(position.positionId).text(position.positionName));
            })
        }).fail(function (response) {
        })
    }

    /**
    * Các event của người dùng
    * DVTHANG(23/09/2020)
    * */
    initEventEmp() {
        $("#myButtonAdd").click(this.onbtnAdd.bind(this));
        $("#btnAddNew").click(this.saveInfor.bind(this));
        $("input[required]").blur(validData.checkRequired); //dùng để gọi đến hàm checkRequired bên dưới ngay khi người dùng ko nhập các textinput có Attribute là required, ví dụ như txtEmployeeCode và txtEmployeeName
        $("#buttonClose").click(this.onHiddenDialog.bind(this));
        $("#buttonCancel").click(this.onHiddenDialog.bind(this));
        $('table#tbListData').on('click', 'tr', this.rowOnClick);
        $("#btnLoad").click(this.reloadData.bind(this));
        $('#btnEdit').click(this.btnEditOnClick.bind(this));
        $('#btnDelete').click(this.btnDeleteOnClick.bind(this));
        $('#buttonYes').click(this.btnYesButton.bind(this));
        $('#buttonNo').click(this.btnNoButton.bind(this));
        $('#buttonCloseNoti').click(this.onHiddenDialogNoti.bind(this));
        $('#btnDuplicate').click(this.onBtnDuplicate.bind(this));
    }

    /**
     * Hàm chi tiết cho nút Edit: Edit thông tin row-seleted
     * Author: DVTHANG(02/10/2020)
     * */
    btnEditOnClick() {
        var self = this;
        //Hiển thị form chi tiết
        //Lấy dữ liệu của nhân viên tương ứng đã chọn:
        //1. Xác định nhân viên nào được chọn:
        var recordSelected = $('#tbListData tbody tr.row-selected');
        if (recordSelected.length > 0) {
            self.FormMode = "Edit";
            //2. Lấy thông tin Mã nhân viên:
            var id = this.getRecordIdSelected();
            this.showDialog();
            //3. Gọi api service để lấy dữ liệu chi tiết của nhân viên vs mã tương ứng
            $.ajax({
                url: "/api/Employees/" + id,
                method: "GET",
                data: "",
                contentType: "application/json",
                dataType: ""
            }).done(function (object) {
                //1. Sau khi lấy được object, thì sẽ bindding dữ liệu lên dialog
                self.showDialog();
                var fields = $('.table-contentInfor input, .table-contentInfor select');
                $.each(fields, function (index, field) {
                    var fieldName = $(field).attr('fieldName');
                    var format = $(field).attr('format');
                    if (format == 'date') {
                        field.value = commonJS.formatDate2(object[fieldName]);
                    }
                    else {
                        field.value = object[fieldName];
                    }
                })
            }).fail(function (response) {
            })
        } else {
            var noti = "Vui lòng chọn row để sửa!";
            this.onShowDialogNoti(noti);
        }
    }

    /**
     * Hàm ẩn dialog Confirm Delete
     * Author: DVTHANG(04/10/2020)
     * */
    onHiddenDialogConfirm() {
        $("#dialogConfirm").hide();
        $(".model").hide();
    }


    //TODO: load tên nhân viên muốn xóa lên dialog (Bạn có chắc muốn xóa nhân viên ABC không?)
    /**
     * Hàm show dialog Confirm Delete
     * Author: DVTHANG(04/10/2020)
     * */
    onShowDialogConfirm() {
        $('#yesNo-question').text("Bạn có chắc muốn xóa nhân viên " + $('.row-selected td:nth-child(2)').text() + " không?");
        $("#dialogConfirm").show();
        $(".model").show();
    }


    /**
    * Hàm ẩn dialog Delete Noti
    * Author: DVTHANG(04/10/2020)
    * */
    onHiddenDialogNoti() {
        $("#dialogNoti").hide();
        $(".model").hide();
    }

    /**
     * Hàm show dialog Delete Noti
     * Author: DVTHANG(04/10/2020)
     * */
    onShowDialogNoti(abc) {
        $("#mySpan").text(abc);
        $("#dialogNoti").show();
        $(".model").show();
    }



    /**
     * Hàm sự kiện cho nút Xóa
     * Author: DVTHANG(04/10/2020)
     * */
    btnDeleteOnClick() {
        var id = this.getRecordIdSelected();
        if (!id) {
            var noti = "Vui lòng chọn nhân viên muốn xóa!";
            this.onShowDialogNoti(noti);
        } else {
            this.onShowDialogConfirm();
        }
    }

    /**
     * Hàm sự kiện cho nút Yes trong Confirm Delete Dialog
     * Author: DVTHANG(04/10/2020)
     * */
    btnYesButton() {

        var self = this;
        var id = this.getRecordIdSelected();
        $.ajax({
            url: "/api/Employees/" + id,
            method: "DELETE"
        }).done(function (response) {
            if (response) {
                self.onHiddenDialogConfirm();
            } else {
                var noti = "Employee không tồn tại!";
                this.onShowDialogNoti(noti);
            }
            self.loadData();

        }).fail(function () {
            var noti = "Xóa thất bại";
            onShowDialogNoti(noti);
        })
    }


    /**
    * Hàm sự kiện cho nút No trong Confirm Delete Dialog
    * Author: DVTHANG(04/10/2020)
    * */
    btnNoButton() {
        this.onHiddenDialogConfirm();
    }


    /**
     * Hàm xử lí lưu dữ liệu nhập vào trên form
     * Author: DVTHANG(24/09/2020)
     * Update: DVTHANG(1/10/2020): viết hàm base
     * */
    saveInfor() {
        var self = this;
        //Các bước add employee vào table
        //1. validate dữ liệu(kiểm tra xem dữ liệu nhập trên form có đúng hay k)
        /*        var method = "POST";*/
        var idSelected = this.getRecordIdSelected();
        var inputRequireds = $("input[required]");  //các input có cùng thuộc tính required
        var emailCheck = $("input[emailCheck]"); //lấy các input có thuộc tính là emailCheck 
        var isValid = true;  //biến check valid của input required
        $.each(inputRequireds, function (index, input) {
            var valid = $(input).trigger("blur");
            if (isValid && valid.hasClass("require-error")) {
                isValid = false;
                var str = "Các trường có dấu (*) không được để trống!";
                self.onShowDialogNoti(str);
            }
        })
        //nếu required input và email input hợp lệ thì sẽ tiến thành các bước tiếp theo
        if (isValid) {
            debugger
            //2. Build object cần lưu:
            var inputs = $('input[fieldName]');
            var selects = $('select[fieldName]');
            var object = {};
            $.each(inputs, function (index, input) {
                var fieldName = $(input).attr('fieldName');
                var value = $(input).val();
                if (fieldName == 'salary') {
                    var value = parseFloat($(input).val());
                }
                object[fieldName] = value;
            })

            $.each(selects, function (index, select) {
                var fieldName = $(select).attr('fieldName');
                var value = $(select).val();
                if (fieldName == 'gender') {
                    var value = parseFloat($(select).val());
                } else if (fieldName == 'workStatus') {
                    var value = parseFloat($(select).val());
                }
                object[fieldName] = value;
            })
            debugger
            if (this.FormMode == "Add") {
                debugger
                $.ajax({
                    url: this.getUrl(),
                    method: "POST",
                    data: JSON.stringify(object),
                    contentType: "application/json"
                }).done(function (response) {
                    self.loadData();
                    self.FormMode = null;
                    $('.table-contentInfor input').val(" ");  //khi thêm dữ liệu lên bảng thì set các input thành khoảng trắng
                    debugger
                }).fail(function (response) {
                    console.log(response.responseJSON.msg);
                    self.onShowDialogNoti(response.responseJSON.msg + " " + ". Vui lòng nhập lại!");
                })
            } else if (this.FormMode == "Edit") {
                debugger
                $.ajax({
                    url: "/api/Employees/" + idSelected,
                    method: "PUT",
                    data: JSON.stringify(object),
                    contentType: "application/json",
                    dataType: "json"
                }).done(function (response) {
                    if (response) {
                        self.loadData();
                        self.FormMode = null;
                        debugger
                    }
                }).fail(function () {

                });
            }
            self.onHiddenDialog();
        }
    }



    /**
    * Event của nút Add new
    * Author: DVTHANG(25/09/2020)
    * */
    onbtnAdd() {
        this.FormMode = "Add";   //Dùng chung 1 dialog, nên phải phân biệt add và edit
        this.showDialog();
    }
    /**
     * Hàm show dialog Add
     * Author: DVTHANG(21/10/2020)
     * */
    showDialog() {
        $('.table-contentInfor input').val(null);  //khi thêm dữ liệu lên bảng thì set các input thành khoảng trắng
        /*        $("#txtEmployeeCode").val(this.AutoUpperCode);*/
        this.getLastedEmployeeCode();
        $(".employee-background").show();
        $(".model").show();
        $("#txtEmployeeCode").focus();  //khi người dùng ấn vào nút show Dialog, thì sẽ focus luôn vào chỗ nhập text EmployeeCode

    }
    /**
     * Hàm re-load data
     * Author: DVTHANG(2/10/2020)
     * */
    reloadData() {
        alert("load");
        this.loadData();
    }

    /**-
    * Ẩn Diaglog Thêm Employee, ẩn lớp màn Model
    * Author: DVTHANG(25/05/2020)
    * */
    onHiddenDialog() {
        $(".employee-background").hide();
        $(".model").hide();
    }

    /**
* hàm để khi click vào 1 row, row được chọn đó sẽ đổi màu
* Author: DVTHANG(25/09/2020)
* */
    rowOnClick() {
        $(this).addClass('row-selected');
        $(this).siblings().removeClass('row-selected');
    }

    /**
     * Lấy ra mã nhân viên lớn nhất rồi tăng lên 1
     * Author: DVTHANG(21/10/2020)
     * */
    getLastedEmployeeCode() {
        this.lastedCode = 0;
        debugger;
        try {
            var self = this;
            $.ajax({
                url: "/api/Employees",
                method: "GET",
                data: "",
                contentType: "application/json",
                dataType: "",
                async: false,
            }).done(function (object) {
                self.lastedCode = object[object.length - 1]["employeeCode"];
                self.lastedCode = self.lastedCode.slice(0, 2) + (parseInt(self.lastedCode.slice(2)) + 1);
                $('#txtEmployeeCode').val($('#txtEmployeeCode').val() + self.lastedCode);

            })
            return self.lastedCode;
        } catch (e) {
        }
    }


    //TODO: Hoàn thành chức năng Nhân bản
    /**
     * Hàm nhân bản 1 bản ghi
     * Author: DVTHANG(21/10/2020)
     * */
    onBtnDuplicate() {
        var self = this;
        var id = this.getRecordIdSelected();
        debugger
        if (!id) {
            var noti = "Vui lòng chọn nhân viên muốn nhân bản!";
            this.onShowDialogNoti(noti);
        } else {
            var obj;
            $.ajax({
                url: "/api/Employees/" + id,
                method: "GET",
                data: "",
                contentType: "application/json",
                dataType: "",
                async: false,
            }).done(function (object) {
                debugger
                object['employeeCode'] = self.getLastedEmployeeCode();
                obj = object;
            }).fail(function (response) {
                debugger
            })
            $.ajax({
                url: "/api/Employees",
                method: "POST",
                data: JSON.stringify(obj),
                contentType: "application/json"
            }).done(function (response) {
                self.loadData();
                debugger
            }).fail(function (response) {
                debugger
            })
        }
    }
}



