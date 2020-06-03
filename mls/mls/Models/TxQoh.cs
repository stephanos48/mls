using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class TxQoh
    {

        public int Txqohid { get; set; }

        public Customer Customer { get; set; }

        public byte CustomerId { get; set; }

        public CustomerDivision CustomerDivision { get; set; }

        public byte CustomerDivisionId { get; set; }

        public MlsDivision MlsDivision { get; set; }

        public byte MlsDivisionId { get; set; }

        public ActivePart ActivePart { get; set; }

        public byte ActivePartId { get; set; }

        public PartType PartType { get; set; }

        public byte PartTypeId { get; set; }

        public string Pn { get; set; }

        public string UhPn { get; set; }

        public string PartDescription { get; set; }

        public int Qoh { get; set; }

        public int NcrQty { get; set; }

        public string Notes { get; set; }

    }
}