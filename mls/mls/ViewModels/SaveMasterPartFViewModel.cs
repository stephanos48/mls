using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mls.Models;

namespace mls.ViewModels
{
    public class SaveMasterPartFViewModel
    {
        public IEnumerable<Customer> Customers { get; set; }

        public IEnumerable<CustomerDivision> CustomerDivisions { get; set; }

        public IEnumerable<MlsDivision> MlsDivisions { get; set; }

        public IEnumerable<PartType> PartTypes { get; set; }

        public IEnumerable<ActivePart> ActiveParts { get; set; }

        public IEnumerable<DocStatus> DocStatuses { get; set; }

        public MasterPartF MasterPartF { get; set; }

        public IEnumerable<FileMasterPartF> FilMasterPartFs { get; set; }
    }
}