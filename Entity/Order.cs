using Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity
{
    public class Order : IEntityBase
    {
        public int Id { get; set; }
        public int PartnerId { get; set; }
        public Partner Partner { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int OrderStatusId { get; set; }
        public PaymentType PaymentType { get; set; }
        public int PaymentTypeId { get; set; }
        public OrderType OrderType { get; set; }
        public int OrderTypeId { get; set; }
        public Counter Counter { get; set; }
        public int CounterId { get; set; }
        public ApplicationUser Customer { get; set; }
        public string CustomerId { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
        public ICollection<ProductOption> ProductOptions { get; set; }
    }
}
