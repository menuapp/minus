using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public bool IsInStock { get; set; }
        public bool AwayOrderAvailable { get; set; }
        public decimal UnitPrice { get; set; }
        public double Rating { get; set; }
        public List<CommentDto> Comments { get; set; }
        public List<ContentDto> Contents { get; set; }
    }
}
