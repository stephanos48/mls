using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class InvTransferLog
    {

        public int InvTransferLogId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Transfer Date")]
        public DateTime? TransferDateTime { get; set; }

        public string InventoryTransferId {get;set;}

        public InvLocation InvLocation { get; set; }

        [Display(Name = "Warehouse")]
        public byte InvLocationId { get; set; }

        [Display(Name = "Customer PN")]
        public string CustomerPn { get; set; }

        public string PartDescription { get; set; }

        [Display(Name = "Transfer Qty")]
        public int? TransferQty { get; set; }

        public string Notes { get; set; }

    }
}