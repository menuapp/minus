using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Domains
{
    public class PartnerDomain
    {
        public int? Id { get; set; }
        public string AssociateName { get; set; }
        public string AssociateUrl { get; set; }
        public string AssociateAddress { get; set; }
        public ICollection<ContentDomain> Contents { get; set; }
        public ICollection<PartnerUserDomain> Users { get; set; }
        public ICollection<ProductCategoryDomain> ProductCategories { get; set; }
        public ICollection<OrderDomain> Orders { get; set; }
    }
}
