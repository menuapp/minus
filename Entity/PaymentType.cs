using Entity.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public enum PaymentTypeEnum { CARD, MOBILE, CASH };
    public class PaymentType
    {
        private PaymentType(PaymentTypeEnum @enum)
        {
            Id = (int)@enum;
            Name = @enum.ToString();
            Description = @enum.GetEnumDescription();
        }

        public PaymentType()
        {

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Order> Orders { get; set; }

        public static implicit operator PaymentType(PaymentTypeEnum @enum) => new PaymentType(@enum);

        public static implicit operator PaymentTypeEnum(PaymentType paymentType) => (PaymentTypeEnum)paymentType.Id;
    }
}
