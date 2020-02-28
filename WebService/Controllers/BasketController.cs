using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Domains;
using Service.Interfaces;
using WebService.DTOs;
using static WebService.Startup;

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

        public async Task<IActionResult> Get()
        {
            await Talk(BackgroundSocketProcessor.wSockets[0].WebSocket);

            return Ok(mapper.Map<List<BasketDto>>(basketService.GetAll()));
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
        public IActionResult UpdateProduct(OrderProductDto product)
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

        public async Task Talk(WebSocket wSocket)
        {
            using (var ms = new MemoryStream())
            {
                try
                {
                    var orders = basketService.GetAll();
                    var serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(IEnumerable<OrderDomain>));
                    serializer.WriteObject(ms, orders);
                    byte[] response = ms.ToArray();
                    ms.Close();
                    await wSocket.SendAsync(new ArraySegment<byte>(response, 0, response.Length), WebSocketMessageType.Text, true, CancellationToken.None);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}