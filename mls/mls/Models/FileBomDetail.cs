using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class FileBomDetail
    {

        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public int BomTrackerId { get; set; }
        public virtual BomTracker BomTracker { get; set; }

    }
}