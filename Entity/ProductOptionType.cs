using Entity.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public enum ProductOptionTypeEnum { EXCLUDE = 1, RADIO = 2, CHECKBOX = 3, SELECT = 4 };
    public class ProductOptionType

    {
        private ProductOptionType(ProductOptionTypeEnum @enum)
        {
            Id = (int)@enum;
            Name = @enum.ToString();
            Description = @enum.GetEnumDescription();
        }

        public ProductOptionType()
        {

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<ProductOption> ProductOptions { get; set; }

        public static implicit operator ProductOptionType(ProductOptionTypeEnum orderTypeEnum) => new ProductOptionType(orderTypeEnum);
        public static implicit operator ProductOptionTypeEnum(ProductOptionType orderType) => (ProductOptionTypeEnum)orderType.Id;
    }
}
