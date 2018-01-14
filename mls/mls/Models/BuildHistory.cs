using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class BuildHistory
    {
        
        public int BuildHistoryId { get; set; }

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
        
        [Display(Name = "Serial Number")]
        public string SerialNo { get; set; }

        [Display(Name = "Quantity")]
        public int Qty { get; set; }

        [Display(Name = "Assembly Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ShipDateTime { get; set; }

        public string AssembledBy { get; set; }

        public string InspectedBy { get; set; }

        public string ShippedBy { get; set; }

        public string Notes { get; set; }
    }
}