using DAL.Context;
using DAL.Interfaces;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IRepositoryEager<Order>
    {
        public OrderRepository(MinusContext context) : base(context)
        {

        }

        public IEnumerable<Order> GetAllEagerly()
        {
            return dbSet.Include(order => order.OrderProducts.Select(orderProducts => orderProducts.Product)).ToList();
        }

        public Order GetByIdEagerly(int id)
        {
            return dbSet.Include(order => order.OrderProducts.Select(orderProducts => orderProducts.Product)).Single(order => order.Id == id);
        }

        public IEnumerable<Order> GetManyEagerly(Expression<Func<Order, bool>> where)
        {
            return dbSet.Include(order => order.OrderProducts.Select(orderProducts => orderProducts.Product)).Where(where).ToList();
        }
    }
}
