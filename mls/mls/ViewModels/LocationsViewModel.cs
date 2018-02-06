using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mls.Models;

namespace mls.ViewModels
{
    public class LocationsViewModel
    {

        public IEnumerable<MasterPartList> MasterPartLists { get; set; }

        public IEnumerable<TxQoh> TxQohs { get; set; }

    }
}