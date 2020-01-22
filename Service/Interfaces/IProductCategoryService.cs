using Service.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface IProductCategoryService
    {
        IEnumerable<ProductCategoryDomain> ListCategories();
        bool AddProduct(ProductCategoryDomain productCategoryDomain);
        ProductCategoryDomain GetProduct(int id);
        bool Delete(ProductCategoryDomain productCategoryDomain);
        void Update(ProductCategoryDomain productCategoryDomain);
    }
}
