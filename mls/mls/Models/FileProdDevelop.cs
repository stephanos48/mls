using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class FileProdDevelop
    {

        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public int ProdDevelopmentId { get; set; }
        public virtual ProdDevelopment ProdDevelopment { get; set; }

    }
}