using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class ScrumStatus
    {
        [Key]
        public int ScrumStatusId { get; set; }

        public string ScrumStatusName { get; set; }

    }
}