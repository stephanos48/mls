using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class PartStockOut
    {

        [Key]
        public int PartStockOutId { get; set; }

        public string PartStockOutName { get; set; }

    }
}