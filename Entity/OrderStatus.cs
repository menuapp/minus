using Entity.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public enum OrderStatusEnum { BASKET = 1, CONFIRMED = 2, CANCELLED = 6, PREPARING = 3, DELIVERY = 4, COMPLETED = 5 };
    public class OrderStatus
    {
        private OrderStatus(OrderStatusEnum @enum)
        {
            Id = (int)@enum;
            Name = @enum.ToString();
            Description = @enum.GetEnumDescription();
        }

        public OrderStatus()
        {

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Order> Orders { get; set; }

        public static implicit operator OrderStatus(OrderStatusEnum orderStatusEnum) => new OrderStatus(orderStatusEnum);
        public static implicit operator OrderStatusEnum(OrderStatus orderStatus) => (OrderStatusEnum)orderStatus.Id;
    }
}
