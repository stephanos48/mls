using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mls.Models;

namespace mls.ViewModels
{
    public class Save1PfepViewModel
    {
        public IEnumerable<PartType> PartTypes { get; set; }

        public Pfep Pfep { get; set; }
    }
}