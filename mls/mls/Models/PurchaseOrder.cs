using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class PurchaseOrder
    {

        public int PurchaseOrderId { get; set; }

        [Display(Name = "MLS PO")]
        public string PoNumber { get; set; }

        [Display(Name = "PO Line")]
        public string PoLine { get; set; }

        public Supplier Supplier { get; set; }

        [Display(Name = "Supplier")]
        public byte SupplierId { get; set; }

        public string ShipToAddress { get; set; }

        public string ConfirmTo { get; set; }

        public string ShipVia { get; set; }

        public string FOB { get; set; }

        public string Terms { get; set; }

        public string Reference { get; set; }

        [Required]
        [Display(Name = "Ref Customer PO")]
        public string CustomerOrderNumber { get; set; }

        [Display(Name = "Ref MLS SO")]
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

        [Display(Name = "Customer PN")]
        public string CustomerPn { get; set; }

        [Display(Name = "MLS PN")]
        public string UhPn { get; set; }

        public string PartDescription { get; set; }

        [Display(Name = "Sales' Price")]
        public decimal? PartPrice { get; set; }

        [Display(Name = "Order Qty")]
        public int OrderQty { get; set; }

        [Display(Name = "Received Qty")]
        public int? ReceivedQty { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? RequestedDateTime { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? PromiseDateTime { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ReceiptDateTime { get; set; }

        public PoOrderStatus PoOrderStatus { get; set; }

        [Display(Name = "Status")]
        public byte PoOrderStatusId { get; set; }

        public string Notes { get; set; }

    }
}