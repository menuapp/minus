using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminUI.Models
{
    public class ProductOptionViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductId { get; set; }
        public int? OrderId { get; set; }
        public ProductOptionTypeEnum Type { get; set; }
        public List<ProductOptionTypeEnum> Types { get; set; }
        public List<ProductOptionItemViewModel> Items { get; set; }
    }
}
