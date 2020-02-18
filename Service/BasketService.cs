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
    public class BasketService : IBasketService
    {
        IBasketRepository basketRepository { get; set; }
        IMapper mapper { get; set; }
        IUnitOfWork unitOfWork { get; set; }
        public BasketService(IBasketRepository basketRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.basketRepository = basketRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public bool Add(BasketDomain domain)
        {
            basketRepository.Add(mapper.Map<Order>(domain));
            unitOfWork.Commit();
            return true;
        }

        public bool Delete(BasketDomain domain)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BasketDomain> GetAll()
        {
            throw new NotImplementedException();
        }

        public BasketDomain GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BasketDomain> GetMany(Expression<Func<BasketDomain, bool>> where)
        {
            throw new NotImplementedException();
        }

        public void Update(BasketDomain domain)
        {
            throw new NotImplementedException();
        }
    }
}
