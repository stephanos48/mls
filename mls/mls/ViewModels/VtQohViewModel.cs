using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace mls.ViewModels
{
    public class VtQohViewModel
    {
        [Key]
        public int Vtqohid { get; set; }

        public string Pn { get; set; }

        public int? Qoh { get; set; }

        public int? NcrQty { get; set; }

        public int? PfepEsg { get; set; }

        [Display(Name = "Pfep VT")]
        public int? PfepVt { get; set; }

        public int? MinVt { get; set; }

        public int? MaxVt { get; set; }

        public int? KbQty { get; set; }

    }
}