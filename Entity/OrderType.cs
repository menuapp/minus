using Entity.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity
{
    public enum OrderTypeEnum { HERE, AWAY };
    public class OrderType
    {
        private OrderType(OrderTypeEnum @enum)
        {
            Id = (int)@enum;
            Name = @enum.ToString();
            Description = @enum.GetEnumDescription();
        }

        public OrderType()
        {

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Order> Orders { get; set; }

        public static implicit operator OrderType(OrderTypeEnum orderTypeEnum) => new OrderType(orderTypeEnum);
        public static implicit operator OrderTypeEnum(OrderType orderType) => (OrderTypeEnum)orderType.Id;
    }
}
