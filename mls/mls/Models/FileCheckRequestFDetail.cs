using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class FileCheckRequestFDetail
    {

        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public int CheckRequestFId { get; set; }
        public virtual CheckRequestF CheckRequestF { get; set; }

    }
}