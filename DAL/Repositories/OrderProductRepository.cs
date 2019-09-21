using DAL.Interfaces;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    class OrderProductRepository : IRepository<OrderProduct>
    {
        public void Add(OrderProduct entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(OrderProduct entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderProduct> GetAll()
        {
            throw new NotImplementedException();
        }

        public OrderProduct GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderProduct> GetMany()
        {
            throw new NotImplementedException();
        }

        public void Update(OrderProduct entity)
        {
            throw new NotImplementedException();
        }
    }
}
