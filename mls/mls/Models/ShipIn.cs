using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class ShipIn
    {
        public int ShipInId { get; set; }

        public Customer Customer { get; set; }

        [Display(Name = "Customer")]
        public byte CustomerId { get; set; }

        public CustomerDivision CustomerDivision { get; set; }

        [Display(Name = "Customer Division")]
        public byte CustomerDivisionId { get; set; }

        public string Destination { get; set; }

        public string ContainerId { get; set; }

        public string ContainerUh { get; set; }

        public string BOL { get; set; }

        public string AMS { get; set; }

        public string CO { get; set; }

        public string Invoice { get; set; }

        public string PoNo { get; set; }

        public string Seal { get; set; }

        public string Port { get; set; }

        public string Pallet { get; set; }

        [Display(Name = "PN")]
        public string Pn { get; set; }

        public string UhPn { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ship Date")]
        public DateTime? Shipdate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "ETA Date")]
        public DateTime? Etadate { get; set; }

        public string ArrivalWk { get; set; }

        [Display(Name = "Quantity")]
        public int Qty { get; set; }

        public string Hub { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Hubeta { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Receiptdate { get; set; }

        public string Receivedby { get; set; }

        public string Qtyconfirmed { get; set; }

        public ShipInStatus ShipInStatus { get; set; }

        [Display(Name = "Status")]
        public byte ShipInStatusId { get; set; }

        [Display(Name = "Notes")]
        public string Notes { get; set; }

    }
}