using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class ShipFileDetail
    {

        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public int ShipPLanFId { get; set; }
        public virtual ShipPlanF ShipPlanF { get; set; }

    }
}