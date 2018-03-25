using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mls.Models;

namespace mls.ViewModels
{
    public class ProductionIndexDataViewModel
    {
        
        public IEnumerable<WorkOrder> WorkOrders { get; set; }

        public IEnumerable<WoDetail> WoDetails { get; set; }

    }
}