using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class CycleCount
    {

        public int CycleCountId { get; set; }

        [Display(Name = "DateCounted")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CycleCountDateTime { get; set; }
        
        [Display(Name = "CustomerPN")]
        public string CustomerPn { get; set; }

        [Display(Name = "SageQty")]
        public int SageQty { get; set; }

        [Display(Name = "PortalQty")]
        public int PortalQty { get; set; }
        
        [Display(Name = "ActualQty")]
        public int ActualQty { get; set; }

        [Display(Name = "SageAdjQty")]
        public int SageAdjQty { get; set; }

        [Display(Name = "PortalAdjQty")]
        public int PortalAdjQty { get; set; }

        [Display(Name = "Locations")]
        public string LocationsCounted { get; set; }

        public string CountedBy { get; set; }

        public string AuditedBy { get; set; }

        [Display(Name = "CountOff - Yes/No")]
        public string CountOff { get; set; }

        public string CorrectedBy { get; set; }

        [Display(Name = "DateCorrected")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CorrectedDateTime { get; set; }

        public string Notes { get; set; }

    }
}