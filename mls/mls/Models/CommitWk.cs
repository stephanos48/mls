using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class CommitWk
    {

        public int CommitWkId { get; set; }

        public string CustomerPn { get; set; }

        public string CalendarWk { get; set; }

        public int? Qty { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Order Date")]
        public DateTime? LastUpdated { get; set; }

        public string UpdatedBy { get; set; }

        public string Notes { get; set; }

    }
}