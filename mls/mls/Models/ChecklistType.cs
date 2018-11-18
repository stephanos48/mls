using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class ChecklistType
    {

        public int ChecklistTypeId { get; set; }

        public string ChecklistName { get; set; }

        public ICollection<Checklist> Checklist { get; set; }

    }
}