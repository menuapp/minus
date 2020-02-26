using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminUI.Models
{
    public class PartnerViewModel
    {
        public int? Id { get; set; }
        public string AssociateName { get; set; }
        public string AssociateUrl { get; set; }
        public string AssociateAddress { get; set; }
        public List<ContentViewModel> Contents { get; set; }
        public List<UserViewModel> Users { get; set; }
        public List<ProductCategoryViewModel> ProductCategories { get; set; }
        public List<OrderViewModel> Orders { get; set; }
    }
}
