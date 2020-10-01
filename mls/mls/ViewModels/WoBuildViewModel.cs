using mls.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mls.ViewModels
{
    public class WoBuildViewModel
    {

        public IEnumerable<Contractor> Contractors { get; set; }

        public WoBuild WoBuild { get; set; }

    }
}