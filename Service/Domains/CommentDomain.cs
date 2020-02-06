using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Domains
{
    public class CommentDomain
    {
        public int? Id { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
        public UserDomain Customer { get; set; }
        public ProductDomain Product { get; set; }
    }
}
