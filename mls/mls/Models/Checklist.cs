using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class Checklist
    {
        
        public int ChecklistId { get; set; }
        [Display(Name = "Department")]
        public byte DepartmentId { get; set; }

        public Department Department { get; set; }

        [Display(Name = "ChecklistType")]
        public byte ChecklistTypeId { get; set; }

        public ChecklistType ChecklistType { get; set; }

        [Display(Name = "Employee")]
        public byte EmployeeId { get; set; }

        public Employee Employee { get; set; }

        [Display(Name = "Action")]
        public string ChecklistAction { get; set; }

        [Display(Name = "Notes")]
        public string Notes { get; set; }

    }
}