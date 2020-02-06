using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Domains
{
    public class OrderDomain
    {
        public int? Id { get; set; }
        public PartnerDomain Partner { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public int OrderStatus { get; set; }
        public OrderTypeEnum OrderType { get; set; }
        public PaymentTypeEnum PaymentType { get; set; }
        public ICollection<OrderProductDomain> OrderProducts { get; set; }
    }
}
