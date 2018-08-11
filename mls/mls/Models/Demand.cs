using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class Demand
    {

        public int DemandId { get; set; }

        public string Pn { get; set; }

        public int? PastDue { get; set; }

        public int? OpenPoQty { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Order Date")]
        public DateTime? UseDate { get; set; }

        public string DemandWk { get; set; }

        public int? DemandWk30 { get; set; }

        public int? DemandWk31 { get; set; }

        public int? DemandWk32 { get; set; }

        public int? DemandWk33 { get; set; }

        public int? DemandWk34 { get; set; }

        public int? DemandWk35 { get; set; }

        public int? DemandWk36 { get; set; }

        public int? DemandWk37 { get; set; }

        public int? DemandWk38 { get; set; }

        public int? DemandWk39 { get; set; }

        public int? DemandWk40 { get; set; }

        public int? DemandWk41 { get; set; }

        public int? DemandWk42 { get; set; }

        public int? DemandWk43 { get; set; }

        public int? DemandWk44 { get; set; }

        public int? DemandWk45 { get; set; }

        public int? DemandWk46 { get; set; }

        public int? DemandWk47 { get; set; }

        public int? DemandWk48 { get; set; }

        public int? DemandWk49 { get; set; }

        public int? DemandWk50 { get; set; }

        public int? DemandWk51 { get; set; }

        public int? DemandWk52 { get; set; }

        public int? DemandWk1 { get; set; }

        public int? DemandWk2 { get; set; }

        public int? DemandWk3 { get; set; }

        public int? DemandWk4 { get; set; }

        public int? DemandWk5 { get; set; }

        public int? DemandWk6 { get; set; }

        public int? DemandWk7 { get; set; }

        public int? DemandWk8 { get; set; }

        public int? DemandWk9 { get; set; }

        public int? DemandWk10 { get; set; }

        public int? DemandWk11 { get; set; }

        public int? DemandWk12 { get; set; }

        public int? DemandWk13 { get; set; }

        public int? DemandWk14 { get; set; }

        public int? DemandWk15 { get; set; }

        public int? DemandWk16 { get; set; }

        public int? DemandWk17 { get; set; }

        public int? DemandWk18 { get; set; }

        public int? DemandWk19 { get; set; }

        public int? DemandWk20 { get; set; }

        public int? DemandWk21 { get; set; }

        public int? DemandWk22 { get; set; }

        public int? DemandWk23 { get; set; }

        public int? DemandWk24 { get; set; }

        public int? DemandWk25 { get; set; }

        public int? DemandWk26 { get; set; }

        public int? DemandWk27 { get; set; }

        public int? DemandWk28 { get; set; }

        public int? DemandWk29 { get; set; }

        public string Notes { get; set; }

    }
}