using mls.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mls.ViewModels
{
    public class NewPoPlanViewModel
    {

        public int PoPlanId { get; set; }

        [Display(Name = "MLS PO")]
        public string PoNumber { get; set; }

        [Display(Name = "PO Line")]
        public string PoLine { get; set; }

        public Supplier Supplier { get; set; }

        [Display(Name = "Supplier")]
        public byte SupplierId { get; set; }

        [Required]
        [Display(Name = "Customer PO")]
        public string CustomerOrderNumber { get; set; }

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

        [Display(Name = "Customer PN")]
        public string CustomerPn { get; set; }

        [Display(Name = "MLS PN")]
        public string UhPn { get; set; }

        public string PartDescription { get; set; }

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

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? PoSentDateTime { get; set; }

        public string PoSentBy { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? PoConfirmedDateTime { get; set; }

        public string PoConfirmedBy { get; set; }

        public string Notes { get; set; }

    }
}