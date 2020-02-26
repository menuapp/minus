using Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity
{
    public class Product : IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public ProductCategory Category { get; set; }

        [Column(TypeName = "BIT(1)")]
        public bool IsInStock { get; set; }

        [Column(TypeName = "BIT(1)")]
        public bool AwayOrderAvailable { get; set; }
        public decimal TotalProductVolume { get; set; }
        public string ProductVolumeUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public double Rating { get; set; }
        public string Description { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Content> Contents { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
        public ICollection<ProductOption> Options { get; set; }
    }
}
