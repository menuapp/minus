using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IOrderRepository : IRepository<Order, int>, IRepositoryEager<Order, int>
    {
    }
}
