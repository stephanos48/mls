using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class CalendarWk
    {

        public int CalendarWkId { get; set; }

        public string WkName { get; set; }

        public string Notes { get; set; }

        public virtual DemandWk DemandWks { get; set; }

        public virtual CommitWk CommitWks { get; set; }
    }
}