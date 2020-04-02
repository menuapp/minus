using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService.DTOs;

namespace WebService.Extensions
{
    public class PaymentDetails
    {
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string ExpireMonth { get; set; }
        public string ExpireYear { get; set; }
        public string Cvc { get; set; }
        public BasketDto Basket { get; set; }
    }
}
