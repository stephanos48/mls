using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class CheckRequest
    {

        public int CheckRequestId { get; set; }

        [Display(Name = "MLS Co")]
        public string MlsCo { get; set; }

        public CheckStatus CheckStatus { get; set; }

        [Display(Name = "Check Status")]
        public byte CheckStatusId { get; set; }

        [Display(Name = "PO / Req No")]
        public string PurchaseOrderNumber { get; set; }

        [Display(Name = "PN")]
        public string PartNumber { get; set; }

        [Display(Name = "Description")]
        public string PartDescription { get; set; }

        [Display(Name = "Check #")]
        public string CheckNo { get; set; }

        [Display(Name = "Amount")]
        public string Amount { get; set; }

        [Display(Name = "Customer")]
        public string Customer { get; set; }

        [Display(Name = "Supplier")]
        public string Supplier { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Request Date")]
        public DateTime? RequestDateTime { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Need Date")]
        public DateTime? MailDateTime { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Actual Mail Date")]
        public DateTime? ActualMailDateTime { get; set; }

        [Display(Name = "Check Ship Method")]
        public string ShipMethod { get; set; }

        [Display(Name = "Tracking Info")]
        public string TrackingInfo { get; set; }

        [Display(Name = "Notes")]
        public string Notes { get; set; }

    }
}