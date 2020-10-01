using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class ExtQoh
    {

        public int ExtQohId { get; set; }

        public string Pn { get; set; }

        public string PartDescription { get; set; }

        public int Qoh { get; set; }

        public string Location { get; set; }

        public string Notes { get; set; }

    }
}