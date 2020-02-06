using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Entity
{
    public class Customer : IdentityUser
    {
        public string Address { get; set; }
        public Content ProfilePhoto { get; set; }
        public int? ProfilePhotoId { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
