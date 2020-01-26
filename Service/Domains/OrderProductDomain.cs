using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Domains
{
    public class OrderProductDomain
    {
        public int? Id { get; set; }
        public ProductDomain Product { get; set; }
        public OrderDomain Order { get; set; }
    }
}
