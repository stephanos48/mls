using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class IncomingLog
    {

        public int IncomingLogId { get; set; }

        public string Pn { get; set; }

        [Display(Name = "Insp Type")]
        public string InspectionType { get; set; }

        public string InspectionLength { get; set; }

        [Display(Name = "Start Date")]
        public DateTime? IncomingStartDate { get; set; }

        public DateTime? IncomingRemovalDate { get; set; }

        [Display(Name = "Insp Method")]
        public string InspectionMethod { get; set; }

        public string InspectionCriteria { get; set; }

        [Display(Name = "Inspection Status")]
        public byte InspectionStatusId { get; set; }

        public InspectionStatus InspectionStatus { get; set; }

        public string Notes { get; set; }

    }
}