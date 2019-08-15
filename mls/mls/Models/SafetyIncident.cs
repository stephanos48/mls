using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class SafetyIncident
    {

        public int SafetyIncidentId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Complaint Date")]
        public DateTime? IncidentDate { get; set; }

        public string IncidentDetails { get; set; }

        public string Employee { get; set; }

        public string IncidentType { get; set; }

        public string CorrectieAction { get; set; }

        public string Notes { get; set; }

    }
}