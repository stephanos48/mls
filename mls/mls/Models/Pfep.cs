using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class Pfep
    {

        [Key]
        public int PfepId { get; set; }

        [Required]
        [Display(Name = "Customer PN")]
        public string CustomerPn { get; set; }

        public PartType PartType { get; set; }

        [Display(Name = "Part Type")]
        public byte PartTypeId { get; set; }

        public int? LtCustomer { get; set; }

        public int? LtTx { get; set; }

        public int? LtOcean { get; set; }

        public int? LtHaimen { get; set; }

        public int? LtAssy { get; set; }

        public int? PfepCustomer { get; set; }

        public int? PfepTx { get; set; }

        public int? PfepOcean { get; set; }

        public int? PfepHaimen { get; set; }

        public int? PfepAssy { get; set; }

        public int? Min { get; set; }

        public int? Max { get; set; }

        public int? KbQty { get; set; }

    }
}