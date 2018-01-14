using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class ScrumDetail
    {

        public int ScrumDetailId { get; set; }

        [Display(Name = "Update")]
        public string ScrumUpdate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Updated")]
        public DateTime? UpdateDateTime { get; set; }

        [Display(Name = "Updated By")]
        public string UpdatePerson { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Prior Due Date")]
        public DateTime? PriorDueDateTime { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "New Due Date")]
        public DateTime? NewDueDateTime { get; set; }

        [Display(Name = "Notes")]
        public string Notes { get; set; }

        public int ScrumId { get; set; }

        public virtual Scrum Scrums { get; set; }

    }
}