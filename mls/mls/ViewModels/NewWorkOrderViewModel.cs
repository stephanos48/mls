using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using mls.Models;

namespace mls.ViewModels
{
    public class NewWorkOrderViewModel
    {

        [Key]
        public int WorkOrderId { get; set; }

        public Customer Customer { get; set; }

        [Display(Name = "Customer")]
        public byte CustomerId { get; set; }

        public CustomerDivision CustomerDivision { get; set; }

        [Display(Name = "Customer Division")]
        public byte CustomerDivisionId { get; set; }

        public MlsDivision MlsDivision { get; set; }

        [Display(Name = "MLS Division")]
        public byte MlsDivisionId { get; set; }

        public WoPartType WoPartType { get; set; }

        [Display(Name = "Part Type")]
        public byte WoPartTypeId { get; set; }

        public string WorkOrderNumber { get; set; }

        [Required]
        [Display(Name = "Customer PN")]
        public string CustomerPn { get; set; }

        [Display(Name = "Quantity")]
        public int Qty { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CreationDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? NeedDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? PromiseDate { get; set; }

        [Display(Name = "Start Time")]
        public string StartTime { get; set; }

        [Display(Name = "Finish Time")]
        public string FinishTime { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CloseDate { get; set; }

        public OrderType OrderType { get; set; }

        [Display(Name = "Order Type")]
        public byte OrderTypeId { get; set; }

        [Display(Name = "Serial Number")]
        public string Sn { get; set; }

        [Display(Name = "Customer PO")]
        public string CustomerPo { get; set; }

        [Display(Name = "MLS SO")]
        public string MlsSo { get; set; }

        public WoOrderStatus WoOrderStatus { get; set; }

        [Display(Name = "WoStatus")]
        public byte WoOrderStatusId { get; set; }

        [Display(Name = "Notes")]
        public string Notes { get; set; }

    }
}