using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class Requisition
    {

        public int RequisitionId { get; set; }

        public Status Status { get; set; }

        [Display(Name = "Status")]
        public byte StatusId { get; set; }

        public string Supplier { get; set; }

        public string Description { get; set; }

        [Display(Name = "Part Number (if known)")]
        public string PartNumber { get; set; }

        [Display(Name = "Request Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? RequestDate { get; set; }

        [Display(Name = "Need Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? NeedDate { get; set; }

        [Display(Name = "ETA Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EtaDate { get; set; }

        public string Requestor { get; set; }

        public string Notes { get; set; }


    }
}