using DAL.Context;
using DAL.Interfaces;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class OrderProductRepository : RepositoryBase<OrderProduct, int>, IOrderProductRepository
    {
        public OrderProductRepository(MinusContext context) : base(context)
        {

        }
    }
}
