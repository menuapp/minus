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
    public class ProductService : IProductService
    {
        IMapper mapper;
        IProductRepository productRepository;
        IUnitOfWork unitOfWork;
        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.mapper = mapper;
            this.productRepository = productRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool Add(ProductDomain productDomain)
        {
            try
            {
                productRepository.Add(mapper.Map<Product>(productDomain));
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }

            return true;
        }

        public bool Delete(ProductDomain productDomain)
        {
            try
            {
                var product = productRepository.GetById((int)productDomain.Id);
                productRepository.Delete(product);

                unitOfWork.Commit();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ProductDomain GetById(int id)
        {
            return mapper.Map<ProductDomain>(productRepository.GetById(id));
        }

        public IEnumerable<ProductDomain> GetAll()
        {
            return mapper.Map<List<ProductDomain>>(productRepository.GetAll());
        }

        public void Update(ProductDomain productDomain)
        {
            var updatedProduct = mapper.Map<Product>(productDomain);
            var product = productRepository.GetById((int)productDomain.Id);

            product.IsInStock = updatedProduct.IsInStock;
            product.Name = updatedProduct.Name;
            product.OrderProducts = updatedProduct.OrderProducts;
            product.ProductVolumeUnit = updatedProduct.ProductVolumeUnit;
            product.TotalProductVolume = updatedProduct.TotalProductVolume;
            product.UnitPrice = updatedProduct.UnitPrice;

            unitOfWork.Commit();
        }

        public IEnumerable<ProductDomain> GetMany(Expression<Func<ProductDomain, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductDomain> GetAllEagerly()
        {
            return mapper.Map<List<ProductDomain>>(productRepository.GetAllEagerly());
        }

        public IEnumerable<ProductDomain> GetManyEagerly(Expression<Func<ProductDomain, bool>> where)
        {
            throw new NotImplementedException();
        }

        public ProductDomain GetByIdEagerly(int id)
        {
            return mapper.Map<ProductDomain>(productRepository.GetByIdEagerly(id));
        }
    }
}
