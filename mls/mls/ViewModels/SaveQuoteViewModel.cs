using mls.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mls.ViewModels
{
    public class SaveQuoteViewModel
    {

        public IEnumerable<Supplier> Suppliers { get; set; }

        public Quote Quote { get; set; }

    }
}