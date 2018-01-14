using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class NcrChina
    {

        public int NcrChinaId { get; set; }
        [Required]
        [Display(Name = "NCR 号")]
        public string NcrNumber { get; set; }

        [Display(Name = "NCR 日子")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? IssueDateTime { get; set; }

        public byte NcrTypeId { get; set; }

        public NcrType NcrType { get; set; }

        [Display(Name = "Customer")]
        public byte CustomerId { get; set; }

        public Customer Customer { get; set; }

        [Display(Name = "Customer Division")]
        public byte CustomerDivisionId { get; set; }

        public CustomerDivision CustomerDivision { get; set; }

        public string PartSupplier { get; set; }

        public string PartNumber { get; set; }

        public string PartDescription { get; set; }

        public string SerialNumber { get; set; }

        public decimal? PartCost { get; set; }

        public int Quantity { get; set; }

        public string DefectDescription { get; set; }

        public string DefectCode { get; set; }

        [Display(Name = "MLS Division")]
        public byte MlsDivisionId { get; set; }

        public MlsDivision MlsDivision { get; set; }

        [Display(Name = "Disposition")]
        public byte? DispositionId { get; set; }

        public Disposition Disposition { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DispositionDateTime { get; set; }

        public string DispositionedBy { get; set; }

        [Display(Name = "Status")]
        public byte StatusId { get; set; }

        public Status Status { get; set; }

        public string ReworkNumber { get; set; }

        public string ReworkCompletedBy { get; set; }

        public decimal? ReworkHrs { get; set; }

        public string ReworkPartsUsed { get; set; }

        public string ReworkPartsScrapped { get; set; }

        public int? ReworkQty { get; set; }

        public string ReworkStatus { get; set; }

        public string ReworkNotes { get; set; }

        public string ScrapNumber { get; set; }

        public int? ScrapQty { get; set; }

        public string ScrapApprovedBy { get; set; }

        public string ScrapApprovalDate { get; set; }

        public string ScrappedBy { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ScrapDate { get; set; }

        public string ScrapNotes { get; set; }

        public string ScrapStatus { get; set; }

        public string RtvNumber { get; set; }

        public string ShipperNumber { get; set; }

        public string RgNumber { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ShipDate { get; set; }

        public string Carrier { get; set; }

        public string TrackingInfo { get; set; }

        public string ShipTo { get; set; }

        public string RtvNotes { get; set; }

        public string RtvStatus { get; set; }

        public virtual ICollection<NcrType> NcrTypes { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }

        public virtual ICollection<CustomerDivision> CustomerDivisions { get; set; }

        public virtual ICollection<MlsDivision> MlsDivisions { get; set; }

        public virtual ICollection<Disposition> Dispositions { get; set; }

        public virtual ICollection<Status> Statuses { get; set; }

    }
}