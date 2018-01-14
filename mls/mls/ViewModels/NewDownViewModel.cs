using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using mls.Models;

namespace mls.ViewModels
{
    public class NewDownViewModel
    {
        [Key]
        public int DownReportId { get; set; }

        public MlsDivision MlsDivision { get; set; }

        [Display(Name = "MLS Division")]
        public byte MlsDivisionId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CreationDateTime { get; set; }

        public string CustomerPn { get; set; }

        public int QtyNeeded { get; set; }

        public string MlsWo { get; set; }

        public string CustomerPo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EstArrivalDateTime { get; set; }

        public DownStatus DownStatus { get; set; }

        [Display(Name = "Down Status")]
        public byte DownStatusId { get; set; }

        public string Reason { get; set; }

        public string Notes { get; set; }

    }
}