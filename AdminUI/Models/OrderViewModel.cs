using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminUI.Models
{
    public class OrderViewModel
    {
        public int? Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int CounterId { get; set; }
        public string CustomerId { get; set; }
        public UserViewModel User { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatusEnum OrderStatus { get; set; }
        public OrderTypeEnum OrderType { get; set; }
        public PaymentTypeEnum PaymentType { get; set; }
        public List<OrderProductViewModel> OrderProducts { get; set; }
        public List<ProductOptionViewModel> ProductOptions { get; set; }
    }
}
