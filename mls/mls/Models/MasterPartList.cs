using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class MasterPartList
    {
        [Key]
        public int PartId { get; set; }

        public Customer Customer { get; set; }

        public byte CustomerId { get; set; }

        public CustomerDivision CustomerDivision { get; set; }

        public byte CustomerDivisionId { get; set; }

        public MlsDivision MlsDivision { get; set; }

        public byte MlsDivisionId { get; set; }

        public ActivePart ActivePart { get; set; }

        public byte ActivePartId { get; set; }

        [Required]
        public string CustomerPn { get; set; }

        public string MlsPn { get; set; }

        public string PartDescription { get; set; }

        public decimal? PartPrice { get; set; }

        public decimal? PartCost { get; set; }

        public decimal? Weight { get; set; }

        public int? StdPack { get; set; }

        public string Notes { get; set; }

        public string Location { get; set; }

        public PartType PartType { get; set; }

        public byte PartTypeId { get; set; }

        public string HtsCode { get; set; }

    }
}