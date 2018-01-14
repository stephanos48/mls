using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class ChOil
    {

        public int ChOilId { get; set; }

        [Display(Name = "Sample Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateSampleTaken { get; set; }

        public string TakenByName { get; set; }

        public string Result { get; set; }

        public string Notes { get; set; }


    }
}