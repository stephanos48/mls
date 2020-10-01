using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mls.Models;

namespace mls.ViewModels
{
    public class SaveWorkOrderViewModel
    {

        public IEnumerable<Customer> Customers { get; set; }

        public IEnumerable<CustomerDivision> CustomerDivisions { get; set; }

        public IEnumerable<MlsDivision> MlsDivisions { get; set; }

        public IEnumerable<WoPartType> WoPartTypes { get; set; }
        
        public IEnumerable<OrderType> OrderTypes { get; set; }

        public IEnumerable<WoOrderStatus> WoOrderStatuses { get; set; }

        public IEnumerable<PartStockOut> PartStockOuts { get; set; }

        public IEnumerable<Contractor> Contractors { get; set; }

        public WorkOrder WorkOrder { get; set; }

    }
}