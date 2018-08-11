using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class WkSchedule
    {

        public int WkScheduleId { get; set; }

        public string WorkWk { get; set; }

        public DateTime WorkDay { get; set; }

        public string Notes { get; set; }
     

    }
}