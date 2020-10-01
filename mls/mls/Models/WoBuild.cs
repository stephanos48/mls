using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class WoBuild
    {

        public int WoBuildId { get; set; }

        [Display(Name = "Wo Enter Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? WoEnterDateTime { get; set; }

        public Contractor Contractor { get; set; }

        [Display(Name = "Contractor")]
        public byte ContractorId { get; set; }

        public string WoNo { get; set; }

        public string CustomerPn { get; set; }

        public int Qty { get; set; }

        public string Notes { get; set; }

    }
}