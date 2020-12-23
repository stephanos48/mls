using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mls.Models;

namespace mls.ViewModels
{
    public class SaveProdDevelopmentViewModel
    {

        public IEnumerable<Customer> Customers { get; set; }

        public IEnumerable<ProdDevelopStatus> ProdDevelopStatuses { get; set; }

        public IEnumerable<FileProdDevelop> FileProdDevelops { get; set; }

        public ProdDevelopment ProdDevelopment { get; set; }

    }
}