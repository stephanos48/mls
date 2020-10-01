using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class WoFDetail
    {

        public int WoFDetailId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? WorkDate { get; set; }

        public string WoResponsible { get; set; }

        public string Objective { get; set; }

        public string StartTime { get; set; }

        public string FinishTime { get; set; }

        public decimal? TotalTime { get; set; }

        public string Risk { get; set; }

        public string RiskAction { get; set; }

        public string Productive { get; set; }

        public string Notes { get; set; }

        public int WorkOrderFId { get; set; }

        public virtual WorkOrderF WorkOrderFs { get; set; }


    }
}