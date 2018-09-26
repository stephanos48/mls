using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class ProductionPlan
    {

        public int ProductionPlanId { get; set; }

        public string ProdStatus { get; set; }

        public string Pn { get; set; }

        public string Description { get; set; }

        public string TotalOrders { get; set; }

        public string OnHold { get; set; }

        public string Schedule { get; set; }

        public string Day1 { get; set; }

        public string Day2 { get; set; }

        public string Day3 { get; set; }

        public string Day4 { get; set; }

        public string Day5 { get; set; }

        public string Day6 { get; set; }

        public string Day7 { get; set; }

        public string Day8 { get; set; }

        public string Day9 { get; set; }

        public string Day10 { get; set; }

        public string Wk3 { get; set; }

        public string Wk4 { get; set; }

        public string Wk5 { get; set; }

        public string Wk6 { get; set; }

        public string Wk7 { get; set; }

        public string Wk8 { get; set; }

        public string Notes { get; set; }
    }
}