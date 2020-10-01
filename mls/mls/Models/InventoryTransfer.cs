using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class InventoryTransfer
    {

        public int InventoryTransferId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Transfer Date")]
        public DateTime? TransferDateTime { get; set; }

        public InvLocation InvLocation { get; set; }

        [Display(Name = "Transfer From Warehouse")]
        public byte InvLocationId { get; set; }

        public FinishInvLocation FinishInvLocation { get; set; }

        [Display(Name = "Transfer To Warehouse")]
        public byte FinishInvLocationId { get; set; }

        [Display(Name = "Customer PN")]
        public string CustomerPn { get; set; }

        public string PartDescription { get; set; }

        [Display(Name = "Transfer from Qty")]
        public int? TransferFromQty { get; set; }

        [Display(Name = "Transfer to Qty")]
        public int? TransferToQty { get; set; }

        public string Carrier { get; set; }

        public string TrackingInfo { get; set; }

        public string ShipToAddress { get; set; }

        public string Notes { get; set; }

        public virtual ICollection<FileInvDetail> FileInvDetails { get; set; }

    }
}