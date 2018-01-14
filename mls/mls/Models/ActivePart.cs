using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class ActivePart
    {
        [Key]
        public int ActivePartId { get; set; }

        public string ActivePartName { get; set; }

    }
}