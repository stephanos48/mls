using mls.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mls.ViewModels
{
    public class SaveQALogViewModel
    {

        public IEnumerable<Customer> Customers { get; set; }

        public IEnumerable<CustomerDivision> CustomerDivisions { get; set; }

        public IEnumerable<MlsDivision> MlsDivisions { get; set; }

        public IEnumerable<ProblemFound> ProblemFounds { get; set; }

        public IEnumerable<Supplier> Suppliers { get; set; }

        public IEnumerable<PartType> PartTypes { get; set; }

        public IEnumerable<QAType> QATypes { get; set; }

        public IEnumerable<CQStatus> CQStatuses { get; set; }

        public IEnumerable<FileQALog> FileQALogs { get; set; }

        public QALog QALog { get; set; }

    }
}