using System;
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

        [Display(Name = "BOMPrice (Yuan)")]
        public string ChinaBom { get; set; }

        [Display(Name = "BOMPrice (USD)")]
        public string UsaBom { get; set; }

        [Display(Name = "Weight (Kg)")]
        public string Weight { get; set; }

        [Display(Name = "X-Rate (Yuan/USD)")]
        public string ExchangeRate { get; set; }

        [Display(Name = "Freight Cost")]
        public string FreightCost { get; set; }

        public string PartPrice { get; set; }

        [Display(Name = "Total Price")]
        public decimal? TotalPrice { get; set; }

        public string PriceBreak { get; set; }

        public string Tariff { get; set; }

        public string Terms { get; set; }

        public string QuoteBy { get; set; }

        public int CQStatusId { get; set; }

        [Display(Name = "CQStatus")]
        public CQStatus CQStatus { get; set; }

        public string Notes { get; set; }

    }
}