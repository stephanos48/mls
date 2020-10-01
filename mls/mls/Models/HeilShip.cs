using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class HeilShip
    {

        public int HeilShipId { get; set; }

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

        [Required]
        [Display(Name = "Customer PO")]
        public string CustomerOrderNo { get; set; }

        [Display(Name = "Customer PO Line")]
        public string CustomerOrderLine { get; set; }

        [Display(Name = "MLS SO")]
        public string SoNumber { get; set; }

        [Display(Name = "MLS WO")]
        public string WoNumber { get; set; }

        [Display(Name = "Customer PN")]
        public string CustomerPn { get; set; }

        [Display(Name = "MLS PN")]
        public string UhPn { get; set; }

        public string PartDescription { get; set; }

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

        public ShipPlanStatus ShipPlanStatus { get; set; }

        [Display(Name = "Status")]
        public byte ShipPlanStatusId { get; set; }

        public CQStatus CQStatus { get; set; }

        [Display(Name = "HOT")]
        public byte CQStatusId { get; set; }

        public string Carrier { get; set; }

        public string TrackingInfo { get; set; }

        public string ShipToAddress { get; set; }

        public string Notes { get; set; }

    }
}