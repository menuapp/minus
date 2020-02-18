using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Content
    {
        public int Id { get; set; }
        public string PhysicalPath { get; set; }
        public string RelativePath { get; set; }
        public int? ProductId { get; set; }
        public int? PartnerId { get; set; }
        public Product Product { get; set; }
        public Partner Partner { get; set; }
        public ApplicationUser Customer { get; set; }
        public ProductCategory ProductCategory { get; set; }
    }
}
