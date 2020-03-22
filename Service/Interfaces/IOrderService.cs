using Service.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface IOrderService : IService<OrderDomain, int>
    {
        bool AddProduct(OrderProductDomain product);
        bool UpdateProduct(OrderProductDomain product);
        bool RemoveProduct(OrderProductDomain product);
        OrderDomain GetBySession(string sessionId);
    }
}
