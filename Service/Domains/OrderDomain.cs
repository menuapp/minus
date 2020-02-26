using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Domains
{
    public class OrderDomain
    {
        public int? Id { get; set; }
        public int PartnerId { get; set; }
        public PartnerDomain Partner { get; set; }
        public DateTime OrderDate { get; set; }
        public int CounterId { get; set; }
        public string CustomerId { get; set; }
        public UserDomain User { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatusEnum OrderStatus { get; set; }
        public OrderTypeEnum OrderType { get; set; }
        public PaymentTypeEnum PaymentType { get; set; }
        public ICollection<OrderProductDomain> OrderProducts { get; set; }
        public ICollection<ProductOptionDomain> ProductOptions { get; set; }
    }
}
