using AutoMapper;
using DAL.Interfaces;
using Entity;
using Service.Domains;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Service
{
    public class ProductCategoryService : IProductCategoryService
    {
        private IProductCategoryRepository productCategoryRepository { get; set; }
        private IMapper mapper { get; set; }
        private IUnitOfWork unitOfWork;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.productCategoryRepository = productCategoryRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public bool Add(ProductCategoryDomain productCategoryDomain)
        {
            productCategoryRepository.Add(mapper.Map<ProductCategory>(productCategoryDomain));
            unitOfWork.Commit();
            return true;
        }

        public bool Delete(ProductCategoryDomain productCategoryDomain)
        {
            try
            {
                var productCategory = productCategoryRepository.GetById((int)productCategoryDomain.Id);
                productCategoryRepository.Delete(productCategory);

                unitOfWork.Commit();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public ProductCategoryDomain GetById(int id)
        {
            return mapper.Map<ProductCategoryDomain>(productCategoryRepository.GetByIdEagerly(id));
        }

        public IEnumerable<ProductCategoryDomain> GetAll()
        {
            return mapper.Map<IEnumerable<ProductCategoryDomain>>(productCategoryRepository.GetAll());
        }

        public void Update(ProductCategoryDomain productCategoryDomain)
        {
            ProductCategory updatedProductCategory = mapper.Map<ProductCategory>(productCategoryDomain);
            ProductCategory productCategory = productCategoryRepository.GetById(updatedProductCategory.Id);

            productCategory.Name = updatedProductCategory.Name;
            productCategory.Partner = updatedProductCategory.Partner;
            productCategory.Products = updatedProductCategory.Products;
            productCategory.Content = updatedProductCategory.Content;

            productCategoryRepository.Update(productCategory);

            unitOfWork.Commit();
        }

        public IEnumerable<ProductCategoryDomain> GetMany(Expression<Func<ProductCategoryDomain, bool>> where)
        {
            return mapper.Map<IEnumerable<ProductCategoryDomain>>(productCategoryRepository.GetManyEagerly(mapper.Map<Expression<Func<ProductCategory, bool>>>(where)));
        }
    }
}
