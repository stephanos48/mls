using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class IncomingTopLevel
    {

        public int IncomingTopLevelId { get; set; }

        public string IncomingVesselNo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? InspectionDateTime { get; set; }

        public string Notes { get; set; }

        public virtual ICollection<IncomingDetail> IncomingDetails { get; set; }

    }
}