using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mls.Models;

namespace mls.ViewModels
{
    public class ScrumIndexDataViewModel
    {

        public IEnumerable<Scrum> Scrums { get; set; }

        public IEnumerable<ScrumDetail> ScrumDetails { get; set; }

    }
}