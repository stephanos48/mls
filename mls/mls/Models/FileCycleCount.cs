using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class FileCycleCount
    {

        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public int CycleCountFId { get; set; }
        public virtual CycleCountF CycleCountF { get; set; }

    }
}