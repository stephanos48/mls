using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mls.Models;
using System.Web.Mvc;

namespace mls.ViewModels
{
    public class SaveCheckRequestFViewModel
    {

        public IEnumerable<CheckStatus> CheckStatuses { get; set; }

        public CheckRequestF CheckRequestF { get; set; }

    }
}