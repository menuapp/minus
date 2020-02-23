using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Domains;
using Service.Interfaces;
using WebService.DTOs;

namespace WebService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private IOrderService basketService { get; set; }
        private IMapper mapper { get; set; }
        public BasketController(IOrderService basketService, IMapper mapper)
        {
            this.basketService = basketService;
            this.mapper = mapper;
        }

        public IActionResult Get()
        {
            var orders = basketService.GetAll();
            return Ok(mapper.Map<List<BasketDto>>(orders));
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(mapper.Map<BasketDto>(basketService.GetById(id)));
        }

        [HttpPost]
        public IActionResult Add(BasketDto basket)
        {
            basket.OrderDate = DateTime.Now.Date;
            basketService.Add(mapper.Map<OrderDomain>(basket));
            return Ok();
        }

        [HttpPost]
        public IActionResult AddProduct(OrderProductDto product)
        {
            basketService.AddProduct(mapper.Map<OrderProductDomain>(product));
            return Ok();
        }
        [HttpPost]
        public IActionResult RemoveProduct(OrderProductDto product)
        {
            basketService.RemoveProduct(mapper.Map<OrderProductDomain>(product));
            return Ok();
        }

        [HttpPost]
        public IActionResult UpdateProduct(ProductDto product)
        {
            basketService.UpdateProduct(mapper.Map<OrderProductDomain>(product));
            return Ok();
        }

        [HttpPost]
        public IActionResult Delete(BasketDto basket)
        {
            basketService.Delete(mapper.Map<OrderDomain>(basket));
            return Ok();
        }

        [HttpPost]
        public IActionResult UpdateStatus(int id, OrderStatusEnum status)
        {
            return Ok();
        }
    }
}