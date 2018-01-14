using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mls.Models;

namespace mls.ViewModels
{
    public class SaveNcrChinaViewModel
    {

        public IEnumerable<NcrType> NcrTypes { get; set; }

        public IEnumerable<Customer> Customers { get; set; }

        public IEnumerable<CustomerDivision> CustomerDivisions { get; set; }

        public IEnumerable<Disposition> Dispositions { get; set; }

        public IEnumerable<MlsDivision> MlsDivisions { get; set; }

        public IEnumerable<Status> Statuses { get; set; }

        public NcrChina NcrChina { get; set; }

    }
}