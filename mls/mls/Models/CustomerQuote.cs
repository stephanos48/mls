﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class CustomerQuote
    {

        [Display(Name = "QuoteId")]
        public int CustomerQuoteId { get; set; }

        public int CustomerId { get; set; }

        [Display(Name = "Customer")]
        public Customer Customer { get; set; }

        public int CustomerDivisionId { get; set; }

        [Display(Name = "Customer Division")]
        public CustomerDivision CustomerDivision { get; set; }

        public int MlsDivisionId { get; set; }

        [Display(Name = "Mls Division")]
        public MlsDivision MlsDivision { get; set; }

        public string Pn { get; set; }

        [Display(Name = "QuoteDate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? QuoteDate { get; set; }

        [Display(Name = "EAU")]
        public string Eau { get; set; }

        public string ChinaBom { get; set; }

        public string Weight { get; set; }

        public string ExchangeRate { get; set; }

        public string QuotedPrice { get; set; }

        public string PriceBreak { get; set; }

        public string Tariff { get; set; }

        public string Terms { get; set; }

        public string QuoteBy { get; set; }

        public string Notes { get; set; }

    }
}