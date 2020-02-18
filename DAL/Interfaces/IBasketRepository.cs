using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IBasketRepository : IRepository<Order, int>, IRepositoryEager<Order, int>
    {
    }
}
