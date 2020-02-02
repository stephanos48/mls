using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class VtPfep
    {

        public int VtPfepId { get; set; }

        [Required]
        [Display(Name = "Customer PN")]
        public string CustomerPn { get; set; }

        public PartType PartType { get; set; }

        [Display(Name = "Part Type")]
        public byte PartTypeId { get; set; }

        public int? QohVt { get; set; }

        public int? NcrQtyVt { get; set; }

        public int? PfepEsg { get; set; }

        [Display(Name = "Pfep VT")]
        public int? PfepVt { get; set; }

        public int? MinVt { get; set; }

        public int? MaxVt { get; set; }

        public int? KbQty { get; set; }

    }
}