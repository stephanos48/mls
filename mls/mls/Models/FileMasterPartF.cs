using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class FileMasterPartF
    {

        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public int MasterPartFId { get; set; }
        public virtual MasterPartF MasterPartF { get; set; }

    }
}