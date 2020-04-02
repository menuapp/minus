using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Domains
{
    public class OrderProductDomain
    {
        public int? Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public ProductDomain Product { get; set; }
        public bool IsDelivered { get; set; }
    }
}
