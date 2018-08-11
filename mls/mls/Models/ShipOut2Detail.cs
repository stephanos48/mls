using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class ShipOut2Detail
    {

        public int ShipOut2DetailId { get; set; }

        public string Pn { get; set; }

        public string Sn { get; set; }

        public int Quantity { get; set; }

        public string ManifestNo { get; set; }

        public string PoNumber { get; set; }

        public string SoNumber { get; set; }

        public string PalletNo { get; set; }

        public string Notes { get; set; }

        public int ShipOut2Id { get; set; }

        public virtual ShipOut2 ShipOut2s { get; set; }

    }
}