using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class Quote
    {

        [Display(Name = "QuoteId")]
        public int QuoteId { get; set; }

        [Display(Name = "Supplier")]
        public byte SupplierId { get; set; }

        public Supplier Supplier { get; set; }

        public string Pn { get; set; }

        [Display(Name = "QuoteDate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? QuoteDate { get; set; }

        public string QuotedPrice { get; set; }

        public string PriceBreak { get; set; }

        public string Tariff { get; set; }

        public string Terms { get; set; }

        public string QuoteBy { get; set; }

        public string Notes { get; set; }
        
    }
}