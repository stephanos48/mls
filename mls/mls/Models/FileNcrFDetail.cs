using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class FileNcrFDetail
    {

        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public int NcrFId { get; set; }
        public virtual NcrF NcrF { get; set; }

    }
}