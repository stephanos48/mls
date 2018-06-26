using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mls.Models;

namespace mls.ViewModels
{
    public class IncomingIndexDataViewModel
    {

        public IEnumerable<IncomingTopLevel> IncomingTopLevels { get; set; }

        public IEnumerable<IncomingDetail> IncomingDetails { get; set; }

    }
}