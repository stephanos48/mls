 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class FileWoDetail
    {


        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public int WorkOrderFId { get; set; }
        public virtual WorkOrderF WorkOrderF { get; set; }


    }
}