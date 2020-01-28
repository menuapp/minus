using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminUI.Models
{
    public class ProductViewModel
    {

        public int? Id { get; set; }
        public string Name { get; set; }
        public bool IsInStock { get; set; }
        public decimal TotalProductVolume { get; set; }
        public bool AwayOrderAvailable { get; set; }
        public string ProductVolumeUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public double Rating { get; set; }
        public int CategoryId { get; set; }
        public IFormFile File { get; set; }
        public List<ContentViewModel> Contents { get; set; }
        public ProductCategoryViewModel Category { get; set; }
    }
}
