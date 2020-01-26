using AutoMapper;
using DAL.Interfaces;
using Entity;
using Service.Domains;
using Service.Interfaces;
using System;
using System.Collections.Generic;
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
            return productRepository.Delete(mapper.Map<Product>(productDomain));
        }

        public ProductDomain GetById(int id)
        {
            return mapper.Map<ProductDomain>(productRepository.GetById(id));
        }

        public IEnumerable<ProductDomain> GetAll()
        {
            return mapper.Map<List<ProductDomain>>(productRepository.GetAll());
        }

        public void Update(ProductDomain ProductDomain)
        {
            throw new NotImplementedException();
        }
    }
}
