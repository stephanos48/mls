using mls.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mls.ViewModels
{
    public class VtSaveShipPlanViewModel
    {
        public IEnumerable<Customer> Customers { get; set; }

        public IEnumerable<CustomerDivision> CustomerDivisions { get; set; }

        public IEnumerable<MlsDivision> MlsDivisions { get; set; }

        public IEnumerable<ShipPlanStatus> ShipPlanStatuses { get; set; }

        public IEnumerable<CQStatus> CQStatuses { get; set; }

        public VtShipPlan VtShipPlan { get; set; }

    }
}