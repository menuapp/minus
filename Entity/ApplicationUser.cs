using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Order> Orders { get; set; }
        public Content ProfilePhoto { get; set; }
        public int? ProfilePhotoId { get; set; }
    }
}
