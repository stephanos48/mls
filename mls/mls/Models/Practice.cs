using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace mls.Models
{
    public partial class Practice
    {

        public int PracticeId { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string PicUrl { get; set; }

        [NotMapped]
        public HttpPostedFileBase UploadImage {get; set;}
        

    }
}