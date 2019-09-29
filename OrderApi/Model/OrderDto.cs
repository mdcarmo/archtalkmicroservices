using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Model
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public int CustomerId { get; set; }
        public decimal Total { get; set; }
        public int TotalItems { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
