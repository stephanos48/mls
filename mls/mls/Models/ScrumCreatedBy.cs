using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class ScrumCreatedBy
    {
        [Key]
        public int CreatedById { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

    }
}