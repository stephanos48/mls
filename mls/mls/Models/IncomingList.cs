using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class IncomingList
    {

        public int IncomingListId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? StartDateTime { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EndDateTime { get; set; }

        [Display(Name = "Part Number(s)")]
        public string PartNumber { get; set; }

        [Display(Name = "% Inspection")]
        public string InspectionPer { get; set; }

        public Customer Customer { get; set; }

        [Display(Name = "Customer")]
        public byte CustomerId { get; set; }

        public CustomerDivision CustomerDivision { get; set; }

        [Display(Name = "Customer Division")]
        public byte CustomerDivisionId { get; set; }

        public MlsDivision MlsDivision { get; set; }

        [Display(Name = "MLS Division")]
        public byte MlsDivisionId { get; set; }

        public string InspectionCriteria { get; set; }

        public string InspectionType { get; set; }

        public InspStatus InspStatus { get; set; }

        [Display(Name = "Status")]
        public byte InspStatusId { get; set; }

        public string Notes { get; set; }

    }
}