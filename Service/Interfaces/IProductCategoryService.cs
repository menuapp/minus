using Service.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface IProductCategoryService
    {
        IEnumerable<ProductCategoryDomain> ListCategories();
        bool AddCategory(ProductCategoryDomain productCategoryDomain);
        ProductCategoryDomain GetCategory(int id);
        bool Delete(ProductCategoryDomain productCategoryDomain);
        void Update(ProductCategoryDomain productCategoryDomain);
    }
}
