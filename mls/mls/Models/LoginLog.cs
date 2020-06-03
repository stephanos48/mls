using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class LoginLog
    {

        public int LoginLogId { get; set; }

        [Display(Name = "User")]
        public string User { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Event Date")]
        public DateTime? EventDateTime { get; set; }

        public string EventType { get; set; }

    }
}