using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mls.Models
{
    public class MlsDivision
    {
        public int MlsDivisionId { get; set; }

        public string MlsDivisionName { get; set; }

        public int NcrChinaId { get; set; }

        public virtual NcrChina NcrChinas { get; set; }
    }
}