using mls.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mls.ViewModels
{
    public class MasterDocViewModel
    {

        public IEnumerable<DocStatus> DocStatuses {get; set;} 

        public IEnumerable<FileDocDetail> FileDocDetails { get; set; }

        public MasterDoc MasterDoc { get; set; }

    }
}