using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class BomTracker
    {

        public int BomTrackerId { get; set; }

        [Display(Name = "BomStatus")]
        public byte BomStatusId { get; set; }

        public BomStatus BomStatus { get; set; }

        public string BomPn { get; set; }

        public string Description { get; set; }

        public string RevLevel { get; set; }

        public string BomCreatorExcel { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "BomCreatedExcel")]
        public DateTime? DateCreatedExcel { get; set; }

        public string BomCreatorSage { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "BomCreatedExcel")]
        public DateTime? DateCreatedSage { get; set; }

        public string BomCreatorPortal { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "BomCreatedExcel")]
        public DateTime? DateCreatedPortal { get; set; }

        public string ApprovedBy { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "DateApproved")]
        public DateTime? DateApproved { get; set; }

        public string Notes { get; set; }

        public virtual ICollection<FileBomDetail> FileBomDetails { get; set; }

    }
}