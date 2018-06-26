using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mls.Models;

namespace mls.ViewModels
{
    public class SaveIncomingViewModel
    {

        public IEnumerable<InspectionStatus> InspectionStatuses { get; set; }

        public IncomingLog IncomingLog { get; set; }

    }
}