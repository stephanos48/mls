using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using mls.Models;

namespace mls.ViewModels
{
    public class MvcMasterDetails
    {

        public string IncomingVesselNo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? InspectionDateTime { get; set; }

        public string Notes { get; set; }

        public List<IncomingDetail> IncomingDetails { get; set; }

    }
}