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
     * @param {Date} date
     */
    formatDate(date) {
        return date.getDate() + "/" + date.getMonth() + "/" + date.getFullYear();
    }


   




}




