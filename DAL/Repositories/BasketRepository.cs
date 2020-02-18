using DAL.Context;
using DAL.Interfaces;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DAL.Repositories
{
    public class BasketRepository : RepositoryBase<Order, int>, IBasketRepository
    {
        public BasketRepository(MinusContext context) : base(context)
        {

        }
        public IEnumerable<Order> GetAllEagerly()
        {
            throw new NotImplementedException();
        }

        public Order GetByIdEagerly(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetManyEagerly(Expression<Func<Order, bool>> where)
        {
            throw new NotImplementedException();
        }
    }
}
