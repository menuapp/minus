using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IProductCategoryRepository : IRepository<ProductCategory, int>, IRepositoryEager<ProductCategory, int>
    {
    }
}
