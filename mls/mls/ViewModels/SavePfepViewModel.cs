using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using mls.Models;

namespace mls.ViewModels
{
    public class SavePfepViewModel
    {

        [Key]
        public int PfepId { get; set; }

        [Required]
        [Display(Name = "Customer PN")]
        public string CustomerPn { get; set; }

        public IEnumerable<PartType> PartTypes { get; set; }

        public int? PfepTx { get; set; }

        public int? Min { get; set; }

        public int? Max { get; set; }

        public int? KbQty { get; set; }

        public string PartDescription { get; set; }

        public int? Qoh { get; set; }

        public int? Ocean { get; set; }

        public int? Oo { get; set; }

        public Pfep Pfep { get; set; }

    }
}