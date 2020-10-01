using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class WorkOrderF
    {

        [Key]
        public int WorkOrderFId { get; set; }

        public Customer Customer { get; set; }

        [Display(Name = "Customer")]
        public byte CustomerId { get; set; }

        public CustomerDivision CustomerDivision { get; set; }

        [Display(Name = "Customer Division")]
        public byte CustomerDivisionId { get; set; }

        public MlsDivision MlsDivision { get; set; }

        [Display(Name = "MLS Division")]
        public byte MlsDivisionId { get; set; }

        public Contractor Contractor { get; set; }

        [Display(Name = "Contractor")]
        public byte ContractorId { get; set; }

        public WoPartType WoPartType { get; set; }

        [Display(Name = "Part Type")]
        public byte WoPartTypeId { get; set; }

        public string WorkOrderNumber { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? NeedDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? PromiseDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ShipDate { get; set; }

        [Required]
        [Display(Name = "Customer PN")]
        public string CustomerPn { get; set; }

        [Display(Name = "Quantity")]
        public int Qty { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CreationDate { get; set; }

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

        public string SageJournalNo { get; set; }

        [Display(Name = "Original SN")]
        public string Sn { get; set; }

        [Display(Name = "New SN")]
        public string NewSn { get; set; }

        [Display(Name = "Customer PO")]
        public string CustomerPo { get; set; }

        [Display(Name = "MLS SO")]
        public string MlsSo { get; set; }

        public WoOrderStatus WoOrderStatus { get; set; }

        [Display(Name = "WoStatus")]
        public byte WoOrderStatusId { get; set; }

        public PartStockOut PartStockOut { get; set; }

        [Display(Name = "Stock Out")]
        public byte PartStockOutId { get; set; }

        [Display(Name = "WO Detail")]
        public string WoNotes { get; set; }

        public string PartsNeeded { get; set; }

        public string PartStockOutNotes { get; set; }

        public string Parts { get; set; }

        public string Equipment { get; set; }

        public string Resources { get; set; }

        [Display(Name = "Notes")]
        public string Notes { get; set; }

        public string Day1 { get; set; }

        public string Day2 { get; set; }

        public string Day3 { get; set; }

        public string Day4 { get; set; }

        public string Day5 { get; set; }

        public string Day6 { get; set; }

        public string Day7 { get; set; }

        public string Day8 { get; set; }

        public string Day9 { get; set; }

        public string Day10 { get; set; }

        public string Wk3 { get; set; }

        public string Wk4 { get; set; }

        public string Wk5 { get; set; }

        public string Wk6 { get; set; }

        public string Wk7 { get; set; }

        public string Wk8 { get; set; }

        public virtual ICollection<WoFDetail> WoFDetails { get; set; }
        public virtual ICollection<DownReport> DownReports { get; set; }
        public virtual ICollection<FileWoDetail> FileWoDetails { get; set; }

    }
}