using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mls.Models;

namespace mls.ViewModels
{
    public class SupplierIndexDataViewModel
    {

        public IEnumerable<Supplier> Suppliers { get; set; }
        public IEnumerable<SupplierContact> SupplierContacts { get; set; }
        
    }
}