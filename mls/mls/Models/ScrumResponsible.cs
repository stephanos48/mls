using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class ScrumResponsible
    {
        [Key]
        public int ResponsibleId { get; set; }

        [Display(Name = "Responsible")]
        public string Responsible { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

    }
}