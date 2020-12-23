using mls.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mls.ViewModels
{
    public class SaveBomTrackerViewModel
    {

        public IEnumerable<BomStatus> BomStatuses { get; set; }

        public IEnumerable<FileBomDetail> FileBomDetails { get; set; }

        public BomTracker BomTracker { get; set; }

    }
}