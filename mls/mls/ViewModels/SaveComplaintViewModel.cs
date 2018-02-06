using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mls.Models;
using System.Web.Mvc;

namespace mls.ViewModels
{
    public class SaveComplaintViewModel
    {

        public IEnumerable<Customer> Customers { get; set; }

        public IEnumerable<CustomerDivision> CustomerDivisions { get; set; }

        public IEnumerable<MlsDivision> MlsDivisions { get; set; }

        public IEnumerable<Status> Statuses { get; set; }

        public IEnumerable<ComplaintSeverity> ComplaintSeverities { get; set; }

        public IEnumerable<ComplaintType> ComplaintTypes { get; set; }

        public CustomerComplaint CustomerComplaint { get; set; }

    }
}