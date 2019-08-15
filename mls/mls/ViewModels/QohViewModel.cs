using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace mls.ViewModels
{
    public class QohViewModel
    {
        [Key]
        public int Txqohid { get; set; }

        public string Pn { get; set; }

        public int Qoh { get; set; }

        public int NcrQty { get; set; }

        public string Notes { get; set; }

    }
}