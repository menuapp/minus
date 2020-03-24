using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminUI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace AdminUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Manager")]
    public class OrdersController : ControllerBase
    {
        private IOrderService orderService { get; set; }
        private IMapper mapper { get; set; }
        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            this.orderService = orderService;
            this.mapper = mapper;
        }
        public async Task<IActionResult> Get()
        {
            var baskets = mapper.Map<List<OrderViewModel>>(orderService.GetAll());
            var orders = baskets.Where(basket => basket.OrderProducts.Count > 0).OrderByDescending(order => order.Id).ToList();

            return Ok(orders);
        }
    }
}