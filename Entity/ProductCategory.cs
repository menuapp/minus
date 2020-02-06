using Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity
{
    public class ProductCategory : IEntityBase
    {
        public int Id { get; set; }
        public int PartnerId { get; set; }
        public Partner Partner { get; set; }
        public string Name { get; set; }
        public Content Content { get; set; }
        public int? ContentId { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
