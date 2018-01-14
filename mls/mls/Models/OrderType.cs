using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class OrderType
    {

        [Key]
        public int OrderTypeId { get; set; }

        public string OrderTypeName { get; set; }

    }
}