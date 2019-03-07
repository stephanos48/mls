﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mls.ViewModels
{
    public class NewReqViewModel
    {

        [Key]
        [Display(Name = "ReqId")]
        public int RequisitionId { get; set; }

        [Display(Name = "PartNumber")]
        public string PartNumber { get; set; }

        public string Description { get; set; }

        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Display(Name = "RequestDate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? RequestDate { get; set; }

        [Display(Name = "NeedDate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? NeedDate { get; set; }

        [Display(Name = "ETADate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EtaDate { get; set; }

        public string Requestor { get; set; }

        public string Notes { get; set; }

    }
}