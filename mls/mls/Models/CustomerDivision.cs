using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class CustomerDivision
    {
        public int CustomerDivisionId { get; set; }

        public string CustomerDivisionName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Website { get; set; }

        public int NcrChinaId { get; set; }

        public virtual NcrChina NcrChinas { get; set; }

        public ICollection<Quote> Quotes { get; set; }

    }
}