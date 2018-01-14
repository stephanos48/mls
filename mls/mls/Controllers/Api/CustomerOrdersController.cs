using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using mls.Models;

namespace mls.Controllers.Api
{
    public class CustomerOrdersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomerOrdersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/customerorders
        public IEnumerable<CustomerOrder> GetCustomerOrders()
        {
            return _context.CustomerOrders.ToList();
        }

        //GET /api/customerorders/1
        public CustomerOrder GetCustomerOrder(int id)
        {
            var customerorder = _context.CustomerOrders.SingleOrDefault(c => c.CustomerOrderId == id);

            if (customerorder == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return customerorder;
        }

        //POST /api/customerorders
        [HttpPost]
        public CustomerOrder CreateCustomerOrder(CustomerOrder customerOrder)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.CustomerOrders.Add(customerOrder);
            _context.SaveChanges();

            return customerOrder;
        }

        // PUT /api/customerorders/1
        [HttpPut]
        public void UpdateCustomerOrder(int id, CustomerOrder customerOrder)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerOrderInDb = _context.CustomerOrders.SingleOrDefault(c => c.CustomerOrderId == id);

            if (customerOrderInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            customerOrderInDb.CustomerOrderNumber = customerOrder.CustomerOrderNumber;
            customerOrderInDb.CustomerDivisionId = customerOrder.CustomerDivisionId;
            customerOrderInDb.CustomerOrderId = customerOrder.CustomerOrderId;
            customerOrderInDb.CustomerId = customerOrder.CustomerId;
            customerOrderInDb.CustomerPn = customerOrder.CustomerPn;
            customerOrderInDb.MlsDivisionId = customerOrder.MlsDivisionId;
            customerOrderInDb.OrderDateTime = customerOrder.OrderDateTime;
            customerOrderInDb.OrderQty = customerOrder.OrderQty;
            customerOrderInDb.OrderStatusId = customerOrder.OrderStatusId;
            customerOrderInDb.PartDescription = customerOrder.PartDescription;
            customerOrderInDb.Notes = customerOrder.Notes;
            customerOrderInDb.PartPrice = customerOrder.PartPrice;
            customerOrderInDb.PromiseDateTime = customerOrder.PromiseDateTime;
            customerOrderInDb.RequestedDateTime = customerOrder.RequestedDateTime;
            customerOrderInDb.ShipQty = customerOrder.ShipQty;
            customerOrderInDb.SoNumber = customerOrder.SoNumber;
            customerOrderInDb.UhPn = customerOrder.UhPn;
            customerOrderInDb.Customer = customerOrder.Customer;
            customerOrderInDb.CustomerDivision = customerOrder.CustomerDivision;


            _context.SaveChanges();
        }

        // DELETE /api/customers/1
        [HttpDelete]
        public void DeleteCustomerOrder(int id)
        {
            var customerInDb = _context.CustomerOrders.SingleOrDefault(c => c.CustomerDivisionId == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.CustomerOrders.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}
