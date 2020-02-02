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
        public int OrderStatus { get; set; }
        public PaymentType PaymentType { get; set; }
        public int PaymentTypeId { get; set; }
        public OrderType OrderType { get; set; }
        public int OrderTypeId { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }

    }
}
