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
    public class OrderService : IOrderService
    {
        private IOrderRepository orderRepository { get; set; }
        private IMapper mapper { get; set; }
        private IUnitOfWork unitOfWork;

        public OrderService(IOrderRepository orderRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public bool Add(OrderDomain domain)
        {
            orderRepository.Add(mapper.Map<Order>(domain));
            unitOfWork.Commit();
            return true;
        }

        public bool Delete(OrderDomain domain)
        {
            return orderRepository.Delete(mapper.Map<Order>(domain));
        }

        public IEnumerable<OrderDomain> GetAll()
        {
            return mapper.Map<IEnumerable<OrderDomain>>(orderRepository.GetAll());
        }

        public OrderDomain GetById(int id)
        {
            return mapper.Map<OrderDomain>(orderRepository.GetByIdEagerly(id));
        }

        public void Update(OrderDomain domain)
        {
            throw new NotImplementedException();
        }
    }
}
