using mls.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mls.ViewModels
{
    public class SaveCustomerQuotesViewModel
    {

        public IEnumerable<Customer> Customers { get; set; }

        public IEnumerable<CustomerDivision> CustomerDivisions { get; set; }

        public IEnumerable<MlsDivision> MlsDivisions { get; set; }

        public CustomerQuote CustomerQuote { get; set; }
        
    }
}