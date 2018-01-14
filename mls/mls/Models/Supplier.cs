using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class Supplier
    {

        public int SupplierId { get; set; }

        public string SupplierName { get; set; }

        public string SupplierNumber { get; set; }

        public string SupplierType { get; set; }

        public int? EstAnnualRev { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

        public string Website { get; set; }

        public string Notes { get; set; }

        public virtual ICollection<SupplierContact> SupplierContacts { get; set; }

    }
}