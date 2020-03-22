using Entity;
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
        public OrderStatusEnum OrderStatus { get; set; }
        public OrderTypeEnum OrderType { get; set; }
        public PaymentTypeEnum PaymentType { get; set; }
        public int CounterId { get; set; }
        public string CustomerId { get; set; }
        public int PartnerId { get; set; }
        public string  SessionId { get; set; }
        public List<OrderProductDto> OrderProducts { get; set; }
    }
}
