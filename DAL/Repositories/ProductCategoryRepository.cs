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
    public class ProductCategoryRepository : RepositoryBase<ProductCategory>, IRepositoryEager<ProductCategory>
    {
        public ProductCategoryRepository(MinusContext context) : base(context)
        {

        }

        public IEnumerable<ProductCategory> GetAllEagerly()
        {
            return dbSet.Include(productCategory => productCategory.Products).ToList();
        }

        public ProductCategory GetByIdEagerly(int id)
        {
            return dbSet.Include(productCategory => productCategory.Products).Single(productCategory => productCategory.Id == id);
        }

        public IEnumerable<ProductCategory> GetManyEagerly(Expression<Func<ProductCategory, bool>> where)
        {
            return dbSet.Include(productCategory => productCategory.Products).Where(where).ToList();
        }
    }
}
