﻿using mls.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mls.ViewModels
{
    public class SaveReqViewModel
    {

        public IEnumerable<ReqStatus> ReqStatuses { get; set; }

        public IEnumerable<MlsDivision> MlsDivisions { get; set; }

        public Requisition Requisition { get; set; }

    }
}