using Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity
{
    public class Product : IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProductCategory Category { get; set; }
        public bool IsInStock { get; set; }
        public decimal TotalProductVolume { get; set; }
        public string ProductVolumeUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public double Rating { get; set; }
        public int CategoryId { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
