using mls.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mls.ViewModels
{
    public class SavePoPlanViewModel
    {

        public IEnumerable<Customer> Customers { get; set; }

        public IEnumerable<CustomerDivision> CustomerDivisions { get; set; }

        public IEnumerable<MlsDivision> MlsDivisions { get; set; }

        public IEnumerable<Supplier> Suppliers { get; set; }

        public IEnumerable<PoOrderStatus> PoOrderStatuses { get; set; }

        public PoPlan PoPlan { get; set; }

    }
}