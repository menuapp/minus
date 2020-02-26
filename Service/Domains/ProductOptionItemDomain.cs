using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Domains
{
    public class ProductOptionItemDomain
    {
        public int Id { get; set; }
        public double AdditionalPrice { get; set; }
        public string Description { get; set; }
        public bool Selected { get; set; }
    }
}
