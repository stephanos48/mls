using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mls.ViewModels
{
    public class BomViewModel
    {

        public int BomNo { get; set; }

        public string UnitNo { get; set; }

        public string DetailPn { get; set; }

        public string Description { get; set; }

        public int Qoh { get; set; }

        public int QtyPer { get; set; }

        public int BuildAbility { get; set; }

        public int NcrQty { get; set; }

    }
}