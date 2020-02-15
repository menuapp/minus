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
    public class ProductRepository : RepositoryBase<Product, int>, IProductRepository, IRepositoryEager<Product, int>
    {
        public ProductRepository(MinusContext context) : base(context)
        {

        }

        public IEnumerable<Product> GetAllEagerly()
        {
            return dbSet.Include(product => product.Category)
                .Include(product => product.OrderProducts.Select(orderProduct => orderProduct.Order)).ToList();
        }

        public Product GetByIdEagerly(int id)
        {
            return dbSet.Include(product => product.Category)
                .Include(product => product.OrderProducts.Select(orderProduct => orderProduct.Order)).Single(product => product.Id == id);
        }

        public Product GetByIdEagerly(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetManyEagerly(Expression<Func<Product, bool>> where)
        {
            return dbSet.Include(product => product.Category)
                .Include(product => product.OrderProducts.Select(orderProduct => orderProduct.Order)).Where(where).ToList();
        }
    }
}
