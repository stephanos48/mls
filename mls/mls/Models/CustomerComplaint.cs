using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class CustomerComplaint
    {

        public int CustomerComplaintId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Complaint Date")]
        public DateTime? ComplaintDate { get; set; }

        [Display(Name = "Customer")]
        public byte CustomerId { get; set; }

        [Display(Name = "Customer Division")]
        public byte CustomerDivisionId { get; set; }

        [Display(Name = "Customer Severity")]
        public byte ComplaintSeverityId { get; set; }

        [Display(Name = "MLS Division")]
        public byte MlsDivisionId {get; set; }

        public string CustomerPn { get; set; }

        [Display(Name = "Complaint Type")]
        public byte ComplaintTypeId { get; set;}

        public string CommplaintDetail { get; set; }

        [Display(Name = "Complaint Status")]
        public byte StatusId { get; set; }

        public string Notes { get; set; }


        public Customer Customer { get; set; }

        public CustomerDivision CustomerDivision { get; set; }

        public ComplaintSeverity ComplaintSeverity { get; set; }

        public MlsDivision MlsDivision { get; set; }

        public ComplaintType ComplaintType { get; set; }

        public Status Status { get; set; }

    }
}