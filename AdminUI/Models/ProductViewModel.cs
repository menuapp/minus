using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminUI.Models
{
    public class ProductViewModel
    {

        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name = "Is in Stock")]
        public bool IsInStock { get; set; }
        [Display(Name = "Total Product")]
        public decimal? TotalProductVolume { get; set; }
        [Display(Name = "Away Order Available")]
        public bool AwayOrderAvailable { get; set; }
        [Display(Name = "Unit")]
        public string ProductVolumeUnit { get; set; }
        [Display(Name = "Unit Price")]
        public decimal UnitPrice { get; set; }
        public int CategoryId { get; set; }
        [Required]
        [Display(Name = "Contents")]
        public List<IFormFile> Files { get; set; }
        public List<ContentViewModel> Contents { get; set; }
        public ProductCategoryViewModel Category { get; set; }
    }
}
