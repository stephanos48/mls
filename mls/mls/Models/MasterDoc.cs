using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class MasterDoc
    {

        public int MasterDocId { get; set; }

        [Display(Name = "DocStatus")]
        public byte DocStatusId { get; set; }

        public DocStatus DocStatus { get; set; }

        public string DocNo { get; set; }

        public string DocTitle { get; set; }

        public string DocOwner { get; set; }

        public string RevLevel { get; set; }

        public string SecuredLocation { get; set; }

        public string ProtectionMethod { get; set; }

        public string RetentionPeriod { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "LastReviewed")]
        public DateTime? LastReviewed { get; set; }

        public string ReviewedBy { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "NextReview")]
        public DateTime? NextReview { get; set; }

        public string ControlledBy { get; set; }

        public string ElecDistribution { get; set; }

        public string DistributionMethod { get; set; }

        public string RecordStorageLocation { get; set; }

        public string RecordDistributionMethod { get; set; }

        public string AssociatedDocs { get; set; }

        public string Notes { get; set; }

        public virtual ICollection<FileDocDetail> FileDocDetails { get; set; }

    }
}