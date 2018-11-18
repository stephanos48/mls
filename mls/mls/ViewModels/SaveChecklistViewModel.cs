using mls.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mls.ViewModels
{
    public class SaveChecklistViewModel
    {

        public IEnumerable<ChecklistType> ChecklistTypes { get; set; }

        public IEnumerable<Department> Departments { get; set; }

        public IEnumerable<Employee> Employees { get; set; }

        public Checklist Checklist { get; set; }

    }
}