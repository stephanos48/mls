using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mls.Models;

namespace mls.ViewModels
{
    public class SaveWoDetailViewModel
    {

        public IEnumerable<Productive> Productives { get; set; }

        public IEnumerable<WoResponsible> WoResponsibles { get; set; }

        public WoDetail WoDetail { get; set; }

    }
}