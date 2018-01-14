using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using mls.Models;

namespace mls.ViewModels
{
    public class NewScrumViewModel
    {

        public int ScrumId { get; set; }

        public ScrumCreatedBy ScrumCreatedBy { get; set; }

        [Display(Name = "Created By")]
        public string CreatedById { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Creation Date")]
        public DateTime? CreationDateTime { get; set; }

        public ScrumResponsible ScrumResponsible { get; set; }

        [Display(Name = "Responsible")]
        public string ResponsibleId { get; set; }

        public Department Department { get; set; }

        [Display(Name = "Department")]
        public byte DepartmentId { get; set; }

        [Display(Name = "Action")]
        public string Action { get; set; }

        public Classification Classification { get; set; }

        [Display(Name = "Classification")]
        public byte ClassificationId { get; set; }

        public ScrumStatus ScrumStatus { get; set; }

        [Display(Name = "Status")]
        public byte ScrumStatusId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Due Date")]
        public DateTime? DueDateTime { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Completion Date")]
        public DateTime? CompletionDateTime { get; set; }

        [Display(Name = "Notes")]
        public string Notes { get; set; }

    }
}