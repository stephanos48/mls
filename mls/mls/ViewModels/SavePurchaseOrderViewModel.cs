using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mls.Models;

namespace mls.ViewModels
{
    public class SavePurchaseOrderViewModel
    {

        public IEnumerable<Supplier> Suppliers { get; set; }

        public IEnumerable<Customer> Customers { get; set; }

        public IEnumerable<CustomerDivision> CustomerDivisions { get; set; }

        public IEnumerable<MlsDivision> MlsDivisions { get; set; }

        public IEnumerable<PoOrderStatus> PoOrderStatuses { get; set; }

        public PurchaseOrder PurchaseOrder { get; set; }

    }
}