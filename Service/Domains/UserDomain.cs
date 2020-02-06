using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Domains
{
    public class UserDomain
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public ContentDomain ProfilePhoto { get; set; }
        public ICollection<OrderDomain> Orders { get; set; }
        public ICollection<CommentDomain> Comments { get; set; }
    }
}
