using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mls.Models;

namespace mls.ViewModels
{
    public class SaveShipInViewModel
    {

        public IEnumerable<Customer> Customers { get; set; }

        public IEnumerable<CustomerDivision> CustomerDivisions { get; set; }
        
        public IEnumerable<ShipInStatus> ShipInStatuses { get; set; }

        public ShipIn ShipIn { get; set; }

    }
}