using AutoMapper;
using DAL.Interfaces;
using Entity;
using Service.Domains;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            try
            {
                var order = mapper.Map<Order>(domain);
                orderRepository.Add(order);

                unitOfWork.Commit();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddProduct(OrderProductDomain product)
        {
            try
            {
                var order = orderRepository.GetByIdEagerly(product.OrderId);

                var productToAdd = mapper.Map<OrderProduct>(product);
                var productInBasket = order.OrderProducts?.FirstOrDefault(op => op.ProductId == productToAdd.ProductId);

                if (productInBasket == null)
                {
                    if (order.OrderProducts == null)
                    {
                        order.OrderProducts = new List<OrderProduct>();
                    }

                    order.OrderProducts.Add(mapper.Map<OrderProduct>(product));
                }
                else
                {
                    productInBasket.Quantity += product.Quantity;
                }

                unitOfWork.Commit();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool UpdateProduct(OrderProductDomain product)
        {
            try
            {
                var order = orderRepository.GetByIdEagerly(product.OrderId);
                var orderProduct = order.OrderProducts.FirstOrDefault(op => op.ProductId == product.ProductId);

                orderProduct.Quantity = product.Quantity;

                unitOfWork.Commit();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool RemoveProduct(OrderProductDomain product)
        {
            try
            {
                var order = orderRepository.GetByIdEagerly(product.OrderId);
                var orderProduct = order.OrderProducts.FirstOrDefault(op => op.ProductId == product.ProductId);

                order.OrderProducts.Remove(orderProduct);
                unitOfWork.Commit();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(OrderDomain domain)
        {
            orderRepository.Delete(mapper.Map<Order>(domain));
            unitOfWork.Commit();
            return true;
        }

        public IEnumerable<OrderDomain> GetAll()
        {
            var orders = orderRepository.GetAllEagerly();
            return mapper.Map<IEnumerable<OrderDomain>>(orders);
        }

        public OrderDomain GetById(int id)
        {
            return mapper.Map<OrderDomain>(orderRepository.GetByIdEagerly(id));
        }

        public OrderDomain GetBySession(string sessionId)
        {
            return mapper.Map<OrderDomain>(orderRepository.GetByProp(order => order.SessionId == sessionId));
        }

        public void Update(OrderDomain domain)
        {
            var updatedOrder = mapper.Map<Order>(domain);
            var order = orderRepository.GetById(domain.Id);

            order.OrderStatusId = updatedOrder.OrderStatusId;
            order.OrderTypeId = updatedOrder.OrderTypeId;
            order.PaymentTypeId = updatedOrder.PaymentTypeId;
            order.CounterId = updatedOrder.CounterId;

            orderRepository.Update(order);
            unitOfWork.Commit();
        }

        public IEnumerable<OrderDomain> GetMany(Expression<Func<OrderDomain, bool>> where)
        {
            return mapper.Map<IEnumerable<OrderDomain>>(orderRepository.GetManyEagerly(mapper.Map<Expression<Func<Order, bool>>>(where)));
        }
    }
}
