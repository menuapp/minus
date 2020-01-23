using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Domains
{
    public class ProductDomain
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public bool IsInStock { get; set; }
        public decimal TotalProductVolume { get; set; }
        public string ProductVolumeUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public double Rating { get; set; }
        public ProductCategoryDomain Category { get; set; }
    }
}
