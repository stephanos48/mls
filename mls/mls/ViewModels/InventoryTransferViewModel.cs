using mls.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mls.ViewModels
{
    public class InventoryTransferViewModel
    {

        public IEnumerable<InvLocation> InvLocations { get; set; }

        public IEnumerable<FinishInvLocation> FinishInvLocations { get; set; }

        public IEnumerable<FileInvDetail> FileInvDetails { get; set; }

        public InventoryTransfer InventoryTransfer { get; set; }

    }
}