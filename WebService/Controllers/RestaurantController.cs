using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using WebService.DTOs;
using static WebService.Startup;

namespace WebService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private IOrderService basketService { get; set; }
        private IMapper mapper { get; set; }
        public RestaurantController(IOrderService basketService, IMapper mapper) : base()
        {
            this.basketService = basketService;
            this.mapper = mapper;
        }
        
        public IActionResult Get()
        {
            try
            {
                BackgroundSocketProcessor.wSockets.ForEach(async (SocketWrapper socketWrapper) =>
                {
                    await Talk(socketWrapper.WebSocket);
                });

                return Ok("orders");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Ok("error");
            }
        }

        public async Task Talk(WebSocket wSocket)
        {
            using (var ms = new MemoryStream())
            {
                try
                {
                    var orders = mapper.Map<List<BasketDto>>(basketService.GetMany(basket => basket.OrderStatus == OrderStatusEnum.CONFIRMED));
                    var serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(List<BasketDto>));
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