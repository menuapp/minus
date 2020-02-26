using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Counter
    {
        public int Id { get; set; }
        public int PartnerId { get; set; }
        public Partner Partner { get; set; }
        public string Name { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
