
/**
 * Class EmployeeJS dùng để quản lý các function
 * Author: DVTHANG(23/09/2020)
 * */
class BaseJS {

    constructor() {
        //Gán mặc định FormMode:
        this.FormMode = null;
        this.getData();
        this.loadData();
        this.loadDepartment();
        this.loadPosition();
        this.initEventEmp();
        this.onHiddenDialog();
        this.onHiddenDialogConfirm();
    }



    /**
    * Hàm load dữ liệu từ mảng employees lên bảng
    *  Author: DVTHANG(23/09/2020)
    * */
    loadData() {

        //Lấy dữ liệu trên server thông qua lời gọi tới api service:
        $.ajax({
            url: "/api/employees",
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
                    //hiển thị row-selected lên dialog
                    $(tr).data('data', obj); // lưu cả object vào attribute là data
                    $(tr).append(td); //append từng thằng td vào tr

                })
                debugger
                $('#tbListData tbody').append(tr);
            })


        }).fail(function response() {
            debugger
        })
    }


    /**
     * Hàm load danh sách department trong dialog
     * Author: DVTHANG(13/10/2020)
     * */
    loadDepartment() {
        debugger

        $.ajax({
            url: "/api/departments",
            method: "GET",
            data: "",
            contentType: "application/json",
            dataType: ""
        }).done(function (response) {
            $.each(response, function (i, department) {
                console.log(department.departmentName);
                $("#departmentName").append($('<option></option>').val(department.departmentId).text(department.departmentName));
            })
            debugger
        }).fail(function (response) {
            debugger
        })
    }


    /**
     * Hàm load danh sách Position trong dialog
     * Author: DVTHANG(13/10/2020)
     * */
    loadPosition() {
        debugger
        $.ajax({
            url: "/api/positions",
            method: "GET",
            data: "",
            contentType: "application/json",
            dataType: ""
        }).done(function (response) {
            $.each(response, function (i, position) {
                console.log(position.positionName);
                $("#positionName").append($('<option></option>').val(position.positionId).text(position.positionName));
            })
            debugger
        }).fail(function (response) {
            debugger
        })
    }

    /**
    * Các event của người dùng
    * DVTHANG(23/09/2020)
    * */
    initEventEmp() {
        $("#myButtonAdd").click(this.onShowDialogAdd.bind(this));
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
    }

    /**
     * Hàm chi tiết cho nút Edit: Edit thông tin row-seleted
     * Author: DVTHANG(02/10/2020)
     * */
    btnEditOnClick() {
        debugger
        this.FormMode = "Edit";
        var self = this;
        //Hiển thị form chi tiết
        //Lấy dữ liệu của nhân viên tương ứng đã chọn:
        //1. Xác định nhân viên nào được chọn:
        var recordSelected = $('#tbListData tbody tr.row-selected');
        if (recordSelected.length > 0) {
            //2. Lấy thông tin Mã nhân viên:
            var CustomerCode = $(recordSelected).children()[0].textContent;
            this.onShowDialogAdd();
            //3. Gọi api service để lấy dữ liệu chi tiết của nhân viên vs mã tương ứng
            $.ajax({
                url: "/customer/" + CustomerCode,
                method: "GET"
            }).done(function (customer) {
                debugger
                if (!customer) {
                    alert("Không có Mã nhân viên tương ứng!");
                } else {
                    //Bindding các thông tin của nhân viên lên form
                    $("#txtCustomerCode").val(customer["CustomerCode"]);
                    $("#txtCustomerName").val(customer["CustomerName"]);
                    $("#txtCustomerCompany").val(customer["CompanyName"]);
                    $("#txtCustomerDateOfBirth").val(customer["DateOfBirth"]);
                    $("#txtCustomerSalary").val(customer["Salary"]);
                    $("#txtCustomerAddress").val(customer["Address"]);
                    $("#txtCustomerPhone").val(customer["Mobile"]);
                    $("#txtCustomerEmail").val(customer["Email"]);

                    /*self.onShowDialogAdd();*/
                    //Chỉnh sửa dữ liệu trên form
                    //Thực hiện cất dữ liệu đã chỉnh sửa
                    //1. Thu thập thông tin đã chỉnh sửa
                    var customerNew = {};
                    customerNew["CustomerCode"] = $("#txtCustomerCode").val();
                    customerNew["CustomerName"] = $("#txtCustomerName").val();
                    customerNew["CompanyName"] = $("#txtCustomerCompany").val();
                    customerNew["DateOfBirth"] = $("#txtCustomerDateOfBirth").val();
                    customerNew["Salary"] = $("#txtCustomerSalary").val();
                    customerNew["Address"] = $("#txtCustomerAddress").val();
                    customerNew["Mobile"] = $("#txtCustomerPhone").val();
                    customerNew["Email"] = $("#txtCustomerEmail").val();
                    //2. Gọi api service thực hiện cất dữ liệu
                    if (self.FormMode == "Edit") {
                        debugger
                        $.ajax({
                            url: "/customer",
                            method: "PUT",
                            data: JSON.stringify(customerNew),
                            contentType: "application/json",
                            dataType: "json"
                        }).done(function (response) {
                            if (response) {
                                self.loadData();
                                debugger
                            }
                        }).fail(function () {

                        })
                    }
                }
            }).fail(function (response) {

            })

        } else {
            alert("Vui long chon row ban muon sua!");
        }






        /* this.FormMode = 'Edit';
         //Lấy thông tin bản ghi đã chọn trong danh sách
         var recordSelected = $('#tbListData tbody tr.row-selected');
         debugger
         //Lấy dữ liệu chi tiết của bản ghi đó
         var id = recordSelected.data('keyId');
         if (recordSelected.length > 0) {
             debugger
             this.onShowDialogAdd();
             var objectDetail = recordSelected.data('data');
 
             //Bindding dữ liệu vào các input tương ứng trên dialog
             var inputs = $('input[fieldName]');
             $.each(inputs, function (index, input) {
                 var fieldName = $(input).attr('fieldName');
                 input.value = objectDetail[fieldName];
                 if ($(input).attr('type') == 'date') {
                     input.value = commonJS.formatDate(objectDetail[fieldName]);
                 }
             });
         } else {
             alert("Vui long chon row ban muon sua!");
         }
 
         //Hiển thị dialog
         $(".employee-background").show();
         $(".model").show();*/
    }

    /**
     * Hàm ẩn dialog Confirm Delete
     * Author: DVTHANG(04/10/2020)
     * */
    onHiddenDialogConfirm() {
        $("#dialogConfirm").hide();
        $(".model").hide();
    }


    /**
     * Hàm show dialog Confirm Delete
     * Author: DVTHANG(04/10/2020)
     * */
    onShowDialogConfirm() {
        $("#dialogConfirm").show();
        $(".model").show();
    }

    /**
     * Hàm sự kiện cho nút Xóa
     * Author: DVTHANG(04/10/2020)
     * */
    btnDeleteOnClick() {
        /*var self = this;*/
        //Lấy id của bản ghi được chọn
        var id = this.getRecordIdSelected();
        if (!id) {
            alert("Vui long chon row ban muon xoa!");
        } else {
            this.onShowDialogConfirm();
            /* $.ajax({
                 url: "/customer/" + id,
                 method: "DELETE"
             }).done(function (response) {
                 if (response) {
                     alert("xoa thanh cong");
                    
                 } else {
                     alert("Customer ko ton tai!");
                 }
                 self.loadData();
             }).fail(function () {
                 alert("Vui long kiem tra lai");
             })*/
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
            url: "/customer/" + id,
            method: "DELETE"
        }).done(function (response) {
            if (response) {
                self.onHiddenDialogConfirm();
            } else {
                alert("Customer ko ton tai!");
            }
            self.loadData();

        }).fail(function () {
            alert("Vui long kiem tra lai");
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
     * Hàm dùng chung để lấy ra id của row được chọn
     * Author: DVTHANG(02/10/2020)
     * */
    getRecordIdSelected() {
        //Lấy id của bản ghi được chọn
        var customerCode = null;
        var recordSelected = $('#tbListData tbody tr.row-selected');
        //Lấy dữ liệu chi tiết của bản ghi đó
        if (recordSelected.length > 0) {
            customerCode = $(recordSelected).children()[0].textContent;
        }
        debugger
        return customerCode;
    }

    /**
     * Hàm xử lí lưu dữ liệu nhập vào trên form
     * Author: DVTHANG(24/09/2020)
     * Update: DVTHANG(1/10/2020): viết hàm base
     * */
    saveInfor() {
        debugger
        this.FormMode = "Add";   //Dùng chung 1 dialog, nên phải phân biệt add và edit
        //Các bước add employee vào table
        //1. validate dữ liệu(kiểm tra xem dữ liệu nhập trên form có đúng hay k)

        var inputRequireds = $("input[required]");  //các input có cùng thuộc tính required
        var emailCheck = $("input[emailCheck]"); //lấy các input có thuộc tính là emailCheck 
        var inputEmail = $(emailCheck).val();   //lấy ra value của input email

        var isValid = true;  //biến check valid của input required
        var isValidEmail = true;  //biến check valid của email input 
        var self = this;
        $.each(inputRequireds, function (index, input) {
            var valid = $(input).trigger("blur");
            if (isValid && valid.hasClass("require-error")) {
                isValid = false;
            }
        })

        //nếu required input và email input hợp lệ thì sẽ tiến thành các bước tiếp theo
        if (isValid) {
            //2. Build object cần lưu:
            var inputs = $('input[fieldName]');
            var customer = {};
            $.each(inputs, function (index, input) {
                var fieldName = $(input).attr('fieldName');
                var value = $(input).val();
                customer[fieldName] = value;
            })

            //3. thêm dữ liệu vào đối tượng
            if (self.FormMode == 'Add') {
                alert('add');
                $.ajax({
                    url: "/customer",
                    method: "POST",
                    data: JSON.stringify(customer),
                    contentType: "application/json",
                    dataType: "json"

                }).done(function (response) {

                    self.loadData();
                    self.FormMode = null;
                    //4. Xử lý sau khi lưu dữ liệu
                    self.onHiddenDialog();
                    $('.table-contentInfor input').val(" ");  //khi thêm dữ liệu lên bảng thì set các input thành khoảng trắng
                    debugger
                }).fail(function (response) {
                    debugger
                })
            } else {
                alert('edit');
            }
        }
    }

    /**
    * Hiển thị Dialog: Thêm mới một Employee
    * Author: DVTHANG(25/05/2020)
    * */
    onShowDialogAdd() {

        $('.table-contentInfor input').val(null);  //khi thêm dữ liệu lên bảng thì set các input thành khoảng trắng
        $(".employee-background").show();
        $(".model").show();
        $("#txtEmployeeCode").focus();  //khi người dùng ấn vào nút show Dialog, thì sẽ focus luôn vào chỗ nhập text EmployeeCode
        $("#txtCustomerCode").focus();
    }


    /**
     * Hàm re-load data
     * Author: DVTHANG(2/10/2020)
     * */
    reloadData() {
        alert("load");
        this.loadData();
    }

    /**
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
}

