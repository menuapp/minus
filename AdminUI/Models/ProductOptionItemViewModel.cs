using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminUI.Models
{
    public class ProductOptionItemViewModel
    {
        public int Id { get; set; }
        public double AdditionalPrice { get; set; }
        public string Description { get; set; }
        public bool Selected { get; set; }
    }
}
