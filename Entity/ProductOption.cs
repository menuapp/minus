using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class ProductOption
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductId { get; set; }
        public int? OrderId { get; set; }
        public Order Order { get; set; }
        public int TypeId { get; set; }
        public ProductOptionType Type { get; set; }
        public ICollection<ProductOptionItem> Items { get; set; }
    }
}
