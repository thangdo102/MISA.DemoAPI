/**
 * Hàm format common 
 * Author: DVTHANG(02/10/2020)
 * */
var commonJS = {
    /**
     * format Money
     * Author: DVTHANG(02/10/2020)
     * */
    formatMoney: function () {
        return this.toString().replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,");
    },

    /**
     * Validate Date
     * Author: DVTHANG(05/10/2020)
     * @param {Date} date: date truyền vào
     */
    formatDate(date) {
        return date.getDate() + "/" + (date.getMonth()+ 1) + "/" + date.getFullYear();
    },

    /**
     * Hàm validate Date từ database lên form
     * @param {any} date : date truyền vào
     */
    formatDate2(date) {
        let part1 = date.slice(0, 10);
        return part1;
        
    }







}




