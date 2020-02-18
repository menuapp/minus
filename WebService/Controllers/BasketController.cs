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
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private IBasketService basketService { get; set; }
        private IProductService productService { get; set; }
        private IMapper mapper { get; set; }
        public BasketController(IBasketService basketService, IProductService productService, IMapper mapper)
        {
            this.productService = productService;
            this.basketService = basketService;
            this.mapper = mapper;
        }

        //[HttpPost]
        [HttpGet]
        public IActionResult Get(/*ProductDto product*/)
        {
            var basket = new BasketDto()
            {
                OrderDate = DateTime.Now.Date,
            };
            basket.Products = new List<ProductDto>();
            basket.Products.Add(mapper.Map<ProductDto>(productService.GetById(1)));

            basketService.Add(mapper.Map<BasketDomain>(basket));
            return Ok();
        }

        public IActionResult Remove(ProductDto product)
        {
            return Ok();
        }
        public IActionResult UpdateProduct(ProductDto product)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Delete(ProductDto product)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult UpdateStatus(int id, OrderStatusEnum status)
        {
            return Ok();
        }
    }
}