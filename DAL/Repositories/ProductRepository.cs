using DAL.Interfaces;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    class ProductRepository : IRepository<Product>
    {
        public void Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetMany()
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
