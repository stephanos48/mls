using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class ExpeditedFreight
    {

        public int ExpeditedFreightId { get; set; }

        [Display(Name = "Exp Freight #")]
        public string ExpeditedFreightNo { get; set; }

        public string PartNumber { get; set; }

        [Display(Name = "Exp Freight Type")]
        public string ExpeditedFreightType { get; set; }

        [Display(Name = "Requested By")]
        public string RequestedBy { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Request Date")]
        public DateTime? RequestDateTime { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Need Date")]
        public DateTime? NeedDateTime { get; set; }

        [Display(Name = "Destination")]
        public string Destination { get; set; }

        [Display(Name = "Reason")]
        public string Reason { get; set; }

        [Display(Name = "Notes")]
        public string Notes { get; set; }

        public virtual ICollection<ExpFreightDetail> ExpFreightDetails { get; set; }
    }
}