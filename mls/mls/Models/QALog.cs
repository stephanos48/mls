using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class QALog
    {

        public int QALogId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "QACreated")]
        public DateTime? QACreated { get; set; }

        public string QANo { get; set; }

        public QAType QAType { get; set; }

        [Display(Name = "QAType")]
        public byte QATypeId { get; set; }

        public PartType PartType { get; set; }

        [Display(Name = "Part Type")]
        public byte PartTypeId { get; set; }

        public MlsDivision MlsDivision { get; set; }

        [Display(Name = "MLS Division")]
        public byte MlsDivisionId { get; set; }

        public Customer Customer { get; set; }

        [Display(Name = "Customer")]
        public byte CustomerId { get; set; }

        public CustomerDivision CustomerDivision { get; set; }

        [Display(Name = "Customer Division")]
        public byte CustomerDivisionId { get; set; }

        public ProblemFound ProblemFound { get; set; }

        [Display(Name = "Found")]
        public byte ProblemFoundId { get; set; }

        public string CustomerPn { get; set; }

        public string ProblemDescription { get; set; }

        public string ContainmentChina { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "CP CHINA")]
        public DateTime? CleanPointChina { get; set; }

        public string ContainmentUSA { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "CP USA")]
        public DateTime? CleanPointUsa { get; set; }

        public string NCRNo { get; set; }

        public CQStatus CQStatus { get; set; }

        [Display(Name = "CA?")]
        public byte CQStatusId { get; set; }

        public string CARNo { get; set; }

        public string Supplier { get; set; }

        public string CustomerCARNo { get; set; }

        public string MLSChampion { get; set; }

        public string SupplierChampion { get; set; }

        public string Notes { get; set; }

        public virtual ICollection<FileQALog> FileQALogs { get; set; }

    }
}