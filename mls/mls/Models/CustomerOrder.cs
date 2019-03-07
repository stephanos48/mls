using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class CustomerOrder
    {

        public int CustomerOrderId { get; set; }

        [Required]
        [Display(Name = "Customer PO")]
        public string CustomerOrderNumber { get; set; }

        [Display(Name ="Customer PO Line")]
        public string CustomerOrderLine { get; set; }

        [Display(Name = "MLS SO")]
        public string SoNumber { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Order Date")]
        public DateTime? OrderDateTime { get; set; }

        public Customer Customer { get; set; }

        [Display(Name = "Customer")]
        public byte CustomerId { get; set; }

        public CustomerDivision CustomerDivision { get; set; }

        [Display(Name = "Customer Division")]
        public byte CustomerDivisionId { get; set; }

        public MlsDivision MlsDivision { get; set; }

        [Display(Name = "MLS Division")]
        public byte MlsDivisionId { get; set; }

        public COrderType COrderType { get; set; }

        [Display(Name = "Order Type")]
        public byte COrderTypeId { get; set; }

        [Display(Name = "Customer PN")]
        public string CustomerPn { get; set; }

        [Display(Name = "MLS PN")]
        public string UhPn { get; set; }

        public string PartDescription { get; set; }

        [Display(Name = "Sales' Price")]
        public decimal? PartPrice { get; set; }

        [Display(Name = "Order Qty")]
        public int OrderQty { get; set; }

        [Display(Name = "Ship Qty")]
        public int? ShipQty { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? RequestedDateTime { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? PromiseDateTime { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ShipDateTime { get; set; }

        public OrderStatus OrderStatus { get; set; }

        [Display(Name = "Status")]
        public byte OrderStatusId { get; set; }

        public string Notes { get; set; }

        //public IEnumerable<SelectListItem> Customers { get; set; }
        //public IEnumerable<SelectListItem> CustomerDivisions { get; set; }
        //public IEnumerable<SelectListItem> MlsDivisions { get; set; }
        //public IEnumerable<SelectListItem> Statuss { get; set; }
    }
}