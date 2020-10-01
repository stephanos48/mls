using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mls.Models;

namespace mls.ViewModels
{
    public class ProductionStockOutFViewModel
    {

        public IEnumerable<WorkOrderF> WorkOrderFs { get; set; }
        public IEnumerable<DownReport> DownReports { get; set; }

    }
}