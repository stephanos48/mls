using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class ShipOut2
    {

        public int ShipOut2Id { get; set; }

        public Customer Customer { get; set; }

        [Display(Name = "Customer")]
        public byte CustomerId { get; set; }

        public CustomerDivision CustomerDivision { get; set; }

        [Display(Name = "Customer Division")]
        public byte CustomerDivisionId { get; set; }

        public FreightType FreightType { get; set; }

        [Display(Name = "Freight Type")]
        public byte FreightTypeId { get; set; }

        public FPaymentMethod FpaymentMethod { get; set; }

        [Display(Name = "Payment Method")]
        public byte FPaymentMethodId { get; set; }

        public string Carrier { get; set; }

        public string TrackingInfo { get; set; }

        public string Destination { get; set; }

        public string Quote { get; set; }

        public string SoldTo { get; set; }

        public string ShipTo { get; set; }

        public string ShipTerms { get; set; }

        public string ShipCity { get; set; }

        public string ShipState { get; set; }

        public string ShipZip { get; set; }

        public string ShipDescription { get; set; }

        public string ShipWeight { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ship Date")]
        public DateTime? ShipDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "ETA Date")]
        public DateTime? ETADate { get; set; }

        public virtual ICollection<ShipOut2Detail> ShipOut2Details { get; set; }

    }
}