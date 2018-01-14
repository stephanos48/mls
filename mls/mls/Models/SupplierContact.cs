using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class SupplierContact
    {
        public int SupplierContactId { get; set; }

        public string SupplierContactName { get; set; }

        public string SupplierContactTitle { get; set; }
        
        public string SupplierContactCell { get; set; }

        public string SupplierContactPhone { get; set; }

        public string SupplierContactFax { get; set; }

        public string SupplierContactEmail { get; set; }

        public string Notes { get; set; }

        public int SupplierId { get; set; }

        public virtual Supplier Suppliers { get; set; }
 
    }
}