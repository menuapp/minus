using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.DTOs
{
    public class OrderProductDto
    {
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public ProductDto Product { get; set; }
        public int OrderId { get; set; }
    }
}
