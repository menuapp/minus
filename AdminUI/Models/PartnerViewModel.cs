using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminUI.Models
{
    public class PartnerViewModel
    {
        public int? Id { get; set; }
        [Required]
        public string AssociateName { get; set; }
        [Required]
        public string AssociateUrl { get; set; }
        [Required]
        public string AssociateAddress { get; set; }
        public List<ContentViewModel> Contents { get; set; }
        public List<UserViewModel> Users { get; set; }
        public List<ProductCategoryViewModel> ProductCategories { get; set; }
        public List<OrderViewModel> Orders { get; set; }
    }
}
