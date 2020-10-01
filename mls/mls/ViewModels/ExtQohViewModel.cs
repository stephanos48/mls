using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mls.ViewModels
{
    public class ExtQohViewModel
    {

        [Key]
        public int ExtQohId { get; set; }

        public string Pn { get; set; }

        public int? Qoh { get; set; }

        public int? Qoh731 { get; set; }

        public int? InvIn { get; set; }

        public int? InvOut { get; set; }

        public int? Wo { get; set; }

        public string Location { get; set; }

        public string Notes { get; set; }

    }
}