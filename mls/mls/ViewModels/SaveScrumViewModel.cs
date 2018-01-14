using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mls.Models;

namespace mls.ViewModels
{
    public class SaveScrumViewModel
    {

        public IEnumerable<Classification> Classifications { get; set; }

        public IEnumerable<Department> Departments { get; set; }

        public IEnumerable<ScrumStatus> ScrumStatuses { get; set; }

        public IEnumerable<ScrumCreatedBy> ScrumCreatedBies { get; set; }

        public IEnumerable<ScrumResponsible> ScrumResponsibles { get; set; }

        public Scrum Scrum { get; set; }

    }
}