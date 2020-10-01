using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mls.Models;

namespace mls.ViewModels
{
    public class ProductionIndexDataFViewModel
    {
        
        public IEnumerable<WorkOrderF> WorkOrderFs { get; set; }

        public IEnumerable<WoFDetail> WoFDetails { get; set; }

    }
}