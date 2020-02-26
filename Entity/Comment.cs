using Entity.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity
{
    public class Comment : IEntityBase
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }

        [Column(TypeName = "BIT(1)")]
        public bool IsVisible { get; set; }
        public string CustomerId { get; set; }
        public ApplicationUser Customer { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }
    }
}
