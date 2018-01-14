using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class NcrType
    {

        public int NcrTypeId { get; set; }

        public string NcrTypeName { get; set; }

        public int NcrChinaId { get; set; }
        
        public virtual NcrChina NcrChinas { get; set; }
    }
}