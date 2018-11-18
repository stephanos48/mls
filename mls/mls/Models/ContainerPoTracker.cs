using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class ContainerPoTracker
    {

        public int ContainerPoTrackerId { get; set; }

        [Required]
        [Display(Name = "PN")]
        public string PartNumber { get; set; }

        [Display(Name = "PO No")]
        public string PoNumber { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "1st Applied Date")]
        public DateTime? Date1stDateTime { get; set; }

        [Display(Name = "Qty 1st Opened")]
        public string Open1stQty { get; set; }

        [Display(Name = "Container Qty")]
        public string ContainerQty { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Qty Confirmed Date")]
        public DateTime? ConfirmedDateTime { get; set; }

        [Display(Name = "Container No")]
        public string ContainerNo { get; set; }

        [Display(Name = "Notes")]
        public string Notes { get; set; }

    }
}