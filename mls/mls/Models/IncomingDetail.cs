using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class IncomingDetail
    {

        public int IncomingDetailId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? InspectionDateTime { get; set; }

        [Display(Name = "Part Number")]
        public string PartNumber { get; set; }

        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; }

        public string InspectionCriteria { get; set; }

        public string InspectionType { get; set; }

        public int? QtyReceived { get; set; }

        public int? QtyInspected { get; set; }

        public int? QtyGood { get; set; }

        public int? QtyBad { get; set; }

        public string InspectorName { get; set; }

        public string Notes { get; set; }

        public int IncomingTopLevelId { get; set; }

        public virtual IncomingTopLevel IncomingTopLevels { get; set; }

    }
}