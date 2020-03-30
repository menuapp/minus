using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using AdminUI.Models;
using AutoMapper;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Domains;
using Service.Interfaces;

namespace AdminUI.Controllers
{
    [Authorize(Roles = "Manager")]
    public class OrderController : Controller
    {
        IOrderService orderService { get; set; }
        IMapper mapper { get; set; }
        public OrderController(IOrderService orderService, IMapper mapper)
        {
            this.mapper = mapper;
            this.orderService = orderService;
        }

        public IActionResult Index()
        {
            List<OrderViewModel> orders = new List<OrderViewModel>();

            orders = mapper.Map<List<OrderViewModel>>(orderService.GetMany(basket => basket.OrderStatus == OrderStatusEnum.CONFIRMED));

            return View(orders);
        }

        public async Task<IActionResult> UpdateForDelivery(int id)
        {
            try
            {
                var order = orderService.GetById(id);
                order.OrderStatus = OrderStatusEnum.DELIVERY;
                orderService.Update(order);

                var tasks = BackgroundSocketProcessor.wSockets.Select(sWrapper => Talk(sWrapper.WebSocket));
                await Task.WhenAll(tasks);

                return Ok("delivery confirmed");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        public async Task Talk(WebSocket wSocket)
        {
            using (var ms = new MemoryStream())
            {
                try
                {
                    var orders = mapper.Map<List<OrderViewModel>>(orderService.GetMany(basket => basket.OrderStatus == OrderStatusEnum.DELIVERY));
                    var serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(List<OrderViewModel>));
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