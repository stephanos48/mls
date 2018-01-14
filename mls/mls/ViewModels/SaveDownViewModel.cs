using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mls.Models;

namespace mls.ViewModels
{
    public class SaveDownViewModel
    {
        
        public IEnumerable<DownStatus> DownStatuses { get; set; }

        public IEnumerable<MlsDivision> MlsDivisions { get; set; }

        public DownReport DownReport { get; set; }

    }
}