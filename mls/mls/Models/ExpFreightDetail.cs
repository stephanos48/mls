using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class ExpFreightDetail
    {

        public int ExpFreightDetailId { get; set; }

        public string ExpediteMode { get; set; }
      
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime? StartDateTime { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Arrival Date")]
        public DateTime? ArrivalDateTime { get; set; }

        public decimal Cost { get; set; }

        public string Notes { get; set; }

        public int ExpeditedFreightId { get; set; }

        public virtual ExpeditedFreight ExpeditedFreights { get; set; }

    }
}