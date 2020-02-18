using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.DTOs
{
    public class BasketDto
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderStatusId { get; set; }
        public int OrderTypeId { get; set; }
        public int PaymentTypeId { get; set; }
        public int CounterId { get; set; }
        public int CustomerId { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}
