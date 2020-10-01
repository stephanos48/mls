using mls.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mls.ViewModels
{
    public class InvTransferLogViewModel
    {

        public IEnumerable<InvLocation> InvLocations { get; set; }

        public InvTransferLog InvTransferLog { get; set; }

    }
}