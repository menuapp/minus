using Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity
{
    public class Comment : IEntityBase
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
        public bool IsVisible { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
