using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class FileDocDetail
    {

        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public int MasterDocId { get; set; }
        public virtual MasterDoc MasterDoc { get; set; }

    }
}