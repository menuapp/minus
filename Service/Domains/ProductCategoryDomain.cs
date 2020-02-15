using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Domains
{
    public class ProductCategoryDomain
    {
        public int? Id { get; set; }
        public PartnerDomain Partner { get; set; }
        public int PartnerId { get; set; }
        public string Name { get; set; }
        public ContentDomain Content { get; set; }
        public ICollection<ProductDomain> Products { get; set; }
    }
}
