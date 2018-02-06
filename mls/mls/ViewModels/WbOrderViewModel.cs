using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mls.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace mls.ViewModels
{
    public class WbOrderViewModel
    {
        [Key]
        public int CustomerOrderId { get; set; }

        [Required]
        [Display(Name = "Customer PO")]
        public string CustomerOrderNumber { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Order Date")]
        public DateTime? OrderDateTime { get; set; }

        [Display(Name = "MLS SO")]
        public string SoNumber { get; set; }

        [Display(Name = "Customer PN")]
        public string CustomerPn { get; set; }

        [Display(Name = "Order Qty")]
        public int OrderQty { get; set; }

        [Display(Name = "Ship Qty")]
        public int? ShipQty { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Promise Date")]
        public DateTime? PromiseDateTime { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "TX Ship Date")]
        public DateTime? ShipDateTime { get; set; }

        [Display(Name = "Notes")]
        public string Notes { get; set; }

    }
}