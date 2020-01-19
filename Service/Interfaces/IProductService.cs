using Service.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductDomain> ListProducts();
        bool AddProduct(ProductDomain ProductDomain);
        ProductDomain GetProduct(int id);
        bool Delete(ProductDomain ProductDomain);
        void Update(ProductDomain ProductDomain);
    }
}
