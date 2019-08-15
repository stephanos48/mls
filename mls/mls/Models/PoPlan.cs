using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class PoPlan
    {

        public int PoPlanId { get; set; }

        [Display(Name = "MLS PO")]
        public string PoNumber { get; set; }

        [Display(Name = "PO Line")]
        public string PoLine { get; set; }

        public Supplier Supplier { get; set; }

        [Display(Name = "Supplier")]
        public byte SupplierId { get; set; }

        [Display(Name = "CustomerPo")]
        public string CustomerOrderNumber { get; set; }

        [Display(Name = "MlsSo")]
        public string SoNumber { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "OrderDate")]
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

        [Display(Name = "CustomerPn")]
        public string CustomerPn { get; set; }

        [Display(Name = "MlsPn")]
        public string UhPn { get; set; }

        public string PartDescription { get; set; }

        [Display(Name = "OrderQty")]
        public int OrderQty { get; set; }

        [Display(Name = "ReceivedQty")]
        public int? ReceivedQty { get; set; }

        public string ContainerId { get; set; }

        public string ContainerUh { get; set; }

        public string FreightFowarder { get; set; }

        public string Destination { get; set; }

        public string AMS { get; set; }

        public string BOL { get; set; }

        public string Pallet { get; set; }

        public string Invoice { get; set; }

        public string ArrivalWk { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? RequestedDateTime { get; set; }

        [Display(Name = "PromiseDate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? PromiseDateTime { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "ShipDate")]
        public DateTime? Shipdate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "EtaDate")]
        public DateTime? Etadate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ReceiptDateTime { get; set; }

        public PoOrderStatus PoOrderStatus { get; set; }

        [Display(Name = "Status")]
        public byte PoOrderStatusId { get; set; }

        public string Notes { get; set; }

    }
}