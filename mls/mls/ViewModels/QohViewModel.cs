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
        public int Id { get; set; }

        public string Pn { get; set; }

        public string UhPn { get; set; }

        public int CustomerId { get; set; }

        public int CustomerDivisionId { get; set; }

        public int MlsDivisionId { get; set; }

        public int PartTypeId { get; set; }

        public int ActivePartId { get; set; }

        public int May11Qoh { get; set; }

        public int? May11Rec { get; set; }

        public int? May11Ship { get; set; }

        public int? May11Wo { get; set; }

        public int? May11Cc { get; set; }

        public int? May11Nc { get; set; }

        public int? Qoh { get; set; }

        public int NcrQty { get; set; }

        public string Notes { get; set; }

    }
}