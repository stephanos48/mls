using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class ProdDevelopment
    {

        public int ProdDevelopmentId { get; set; }

        public Customer Customer { get; set; }

        [Display(Name = "Customer")]
        public byte CustomerId { get; set; }

        public string ReverseLocation { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Receipt Date")]
        public DateTime? ReceiptDateTime { get; set; }

        public string IncCarrier { get; set; }

        public string IncTrackingInfo { get; set; }

        [Display(Name = "Customer PN")]
        public string CustomerPn { get; set; }

        [Display(Name = "MLS PN")]
        public string UhPn { get; set; }

        public string PartDescription { get; set; }

        [Display(Name = "SN")]
        public string SerialNo { get; set; }

        [Display(Name = "Receipt Qty")]
        public int ReceiptQty { get; set; }

        public ProdDevelopStatus ProdDevelopStatus { get; set; }

        [Display(Name = "Status")]
        public byte ProdDevelopStatusId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ShipDateTime { get; set; }

        public string ShipCarrier { get; set; }

        public string ShipTrackingInfo { get; set; }

        public string ShipToLocation { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? RoughDesignBomCompletionDateTime { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? QuoteCompletionDateTime { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CustomerPoDateTime { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FinalDesignCompletionDateTime { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CustomerSignOffDateTime { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? PrototypeCompletionDateTime { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? LabTestCompletionDateTime { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CustomerTestCompletionDateTime { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FieldTrialCompletionDateTime { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ApprovedForProductionDateTime { get; set; }

        public string Notes { get; set; }

        public virtual ICollection<FileProdDevelop> FileProdDevelops { get; set; }

    }
}