using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Udaan_Product.Models
{
    public class UdaanProduct
    {
        [Required(ErrorMessage = "Name is Required")]
        public string Product_Name { get; set; }
        [Required(ErrorMessage = "Type is Required")]
        public string Product_Type { get; set; }
        [Required(ErrorMessage = "Price is Required")]
        public string Product_Price { get; set; }
        [Range(1,1000, ErrorMessage = "Must under this Range")]
        public string No_of_Quantity { get; set; }
        public DateTime Deal_Time_From { get; set; }
        public DateTime Deal_Time_To { get; set; }
        [Required(ErrorMessage = "Is_Active Deal is Required")]
        public int Is_Active_Deal { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }

    public class UdaanProductData
    {
        public string Product_Name { get; set; }
        public string Product_Type { get; set; }
        public string Product_Price { get; set; }
        public string No_of_Quantity { get; set; }
        public DateTime Deal_Time_From { get; set; }
        public DateTime Deal_Time_To { get; set; }
        public int Is_Active_Deal { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
