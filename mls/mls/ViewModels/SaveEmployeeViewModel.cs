using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mls.Models;

namespace mls.ViewModels
{
    public class SaveEmployeeViewModel
    {

        public IEnumerable<Department> Departments { get; set; }

        public Employee Employee { get; set; }

    }
}