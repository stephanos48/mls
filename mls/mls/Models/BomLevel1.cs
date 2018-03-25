using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class BomLevel1
    {

        public int BomLevel1Id { get; set; }

        public int BomNo { get; set; }

        public string UnitNo { get; set; }

        public string DetailPn { get; set; }

        public string Description { get; set; }

        public string PurchaseMake { get; set; }

        public string PartType { get; set; }

        public string PartTypeDetail { get; set; }

        public int QtyPer { get; set; }

    }
}