using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class ProductOptionItem
    {
        public int Id { get; set; }
        public int ProductOptionId { get; set; }
        public ProductOption ProductOption { get; set; }
        public double AdditionalPrice { get; set; }
        public string Description { get; set; }
        public bool Selected { get; set; }
    }
}
