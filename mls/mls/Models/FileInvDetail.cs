using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class FileInvDetail
    {

        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public int InventoryTransferId { get; set; }
        public virtual InventoryTransfer InventoryTransfer { get; set; }

    }
}