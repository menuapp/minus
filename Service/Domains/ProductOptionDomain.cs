using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Domains
{
    public class ProductOptionDomain
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductId { get; set; }
        public int? OrderId { get; set; }
        public ProductOptionTypeEnum Type { get; set; }
        public ICollection<ProductOptionItemDomain> Items { get; set; }
    }
}
