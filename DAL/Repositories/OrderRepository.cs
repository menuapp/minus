using DAL.Interfaces;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    class OrderRepository : IRepository<Order>
    {
        public void Add(Order entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Order entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public Order GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetMany()
        {
            throw new NotImplementedException();
        }

        public void Update(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
