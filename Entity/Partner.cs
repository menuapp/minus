using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Partner
    {
        public int Id { get; set; }
        public string AssociateName { get; set; }
        public string AssociateUrl { get; set; }
        public string AssociateAddress { get; set; }
        public ICollection<Content> Contents { get; set; }
        public ICollection<PartnerUser> Users { get; set; }
    }
}
