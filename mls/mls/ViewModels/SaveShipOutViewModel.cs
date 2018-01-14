using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mls.Models;

namespace mls.ViewModels
{
    public class SaveShipOutViewModel
    {

        public IEnumerable<Customer> Customers { get; set; }

        public IEnumerable<CustomerDivision> CustomerDivisions { get; set; }

        public IEnumerable<FreightType> FreightTypes { get; set; }

        public IEnumerable<FPaymentMethod> FPaymentMetods { get; set; }

        public ShipOut ShipOut { get; set; }


    }
}