using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mls.ViewModels
{
    public class NewChecklistViewModel
    {

        public int ChecklistId { get; set; }

        [Display(Name = "Employee")]
        public int Employee { get; set; }

        [Display(Name = "Action")]
        public string ChecklistAction { get; set; }

        [Display(Name = "Notes")]
        public string Notes { get; set; }

    }
}