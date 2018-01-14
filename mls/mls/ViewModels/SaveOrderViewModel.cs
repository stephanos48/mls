using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using mls.Models;


namespace mls.ViewModels
{
    public class SaveOrderViewModel
    {

        public IEnumerable<Customer> Customers { get; set; }

        public IEnumerable<CustomerDivision> CustomerDivisions { get; set; }

        public IEnumerable<MlsDivision> MlsDivisions { get; set; }

        public IEnumerable<OrderStatus> OrderStatuses { get; set; }

        public CustomerOrder CustomerOrder { get; set; }
    }
}