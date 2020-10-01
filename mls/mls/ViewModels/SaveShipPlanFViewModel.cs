using mls.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mls.ViewModels
{
    public class SaveShipPlanFViewModel
    {
        public IEnumerable<Customer> Customers { get; set; }

        public IEnumerable<CustomerDivision> CustomerDivisions { get; set; }

        public IEnumerable<MlsDivision> MlsDivisions { get; set; }

        public IEnumerable<ShipPlanStatus> ShipPlanStatuses { get; set; }

        public IEnumerable<CQStatus> CQStatuses { get; set; }

        public IEnumerable<ShipFileDetail> ShipFileDetails { get; set; }

        public ShipPlanF ShipPlanF { get; set; }

    }
}