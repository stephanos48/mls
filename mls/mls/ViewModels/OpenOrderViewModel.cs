using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mls.ViewModels
{
    public class OpenOrderViewModel
    {

        [Key]
        public int CustomerOrderId { get; set; }

        public int OrderStatusId { get; set; }

        [Display(Name = "Customer")]
        public int CustomerDivisionId { get; set; }

        [Required]
        [Display(Name = "Customer PO")]
        public string CustomerPo { get; set; }

        [Display(Name = "Order Line")]
        public string CustomerOrderLine { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Order Date")]
        public DateTime? OrderDateTime { get; set; }

        [Display(Name = "MLS SO")]
        public string SoNumber { get; set; }

        [Display(Name = "Customer PN")]
        public string CustomerPn { get; set; }

        [Display(Name = "Description")]
        public string PartDescription { get; set; }

        [Display(Name = "OH Qty")]
        public int OhQty { get; set; }

        [Display(Name = "Order Qty")]
        public int OrderQty { get; set; }

        [Display(Name = "Ship Qty")]
        public int? ShipQty { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Request Date")]
        public DateTime? RequestedDateTime { get; set; }

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