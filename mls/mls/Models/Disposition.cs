using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class Disposition
    {

        public int DispositionId { get; set; }

        public string DispositionType { get; set; }

        public int NcrChinaId { get; set; }

        public virtual NcrChina NcrChinas { get; set; }

    }
}