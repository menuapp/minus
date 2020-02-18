using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Domains
{
    public class BasketDomain
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderStatusId { get; set; }
        public int OrderTypeId { get; set; }
        public int PaymentTypeId { get; set; }
        public int CounterId { get; set; }
        public int CustomerId { get; set; }
        public UserDomain User { get; set; }
        public List<ProductDomain> Products { get; set; }
    }
}
