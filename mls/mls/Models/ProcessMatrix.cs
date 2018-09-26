using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class ProcessMatrix
    {

        public int ProcessMatrixId { get; set; }

        public ProcessStatus ProcessStatus { get; set; }

        [Display(Name = "Process Status")]
        public byte ProcessStatusId { get; set; }

        public string DocumentNo { get; set; }

        public string DocumentTitle { get; set; }

        public string RevLevel { get; set; }

        public string SecuredStoreLocation { get; set; }

        public string ProtectionMethod { get; set; }

        public string RetentionPeriod { get; set; }

        public string ControlledBy { get; set; }

        public string ElectronicDistribution { get; set; }

        public string DistributionMethod { get; set; }

        public string RecordStorageLocation { get; set; }

        public string RecordDispostionMethod { get; set; }

        public string DocumentOwner { get; set; }

        public string Notes { get; set; }

        public string PicUrl { get; set; }

        [NotMapped]
        public HttpPostedFileBase UploadImage { get; set; }

    }
}