using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public double Rating { get; set; }
        public List<ContentDto> Contents { get; set; }
        public string Description { get; set; }
    }
}
