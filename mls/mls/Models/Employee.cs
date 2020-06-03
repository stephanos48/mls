using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class Employee
    {

        public int EmployeeId { get; set; }

        public string EmployeeSageId { get; set; }

        public string EmployeeFirstName { get; set; }

        public string EmployeeMiddleName { get; set; }

        public string EmployeeLastName { get; set; }

        public string EmployeeTitle { get; set; }

        public Department Department { get; set; }

        [Display(Name = "Department")]
        public byte DepartmentId { get; set; }

        public string EmployeeEmail { get; set; }

        public string EmployeeCell { get; set; }

        public string EmployeeAddress { get; set; }

        public string EmployeeCity { get; set; }

        public string EmployeeState { get; set; }

        public string EmployeeZip { get; set; }

        public string EmployeeCountry { get; set; }

        public string EmployeeNotes { get; set; }

        public ICollection<Checklist> Checklist { get; set; }

        //public virtual ICollection<FileDetail> FileDetails { get; set; }

    }
}