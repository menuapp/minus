using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Domains
{
    public class ProductCategoryDomain
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ProductDomain> Products { get; set; }
    }
}
