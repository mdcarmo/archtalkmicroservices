using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GatewayApi.Models
{

    internal class CustomerWithOrders
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IList<Order> Orders { get; set; }

        public CustomerWithOrders()
        {
            Orders = new List<Order>();
        }
    }

    internal class Order
    {
        public Guid Id { get; set; }
        public int CustomerId { get; set; }
        public decimal Total { get; set; }
        public int TotalItems { get; set; }
        public DateTime DateCreated { get; set; }
    }
}

