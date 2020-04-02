using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
using static AdminUI.Startup;

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

        public IActionResult Index(bool partial = false)
        {
            List<OrderViewModel> orders = new List<OrderViewModel>();

            orders = mapper.Map<List<OrderViewModel>>(orderService.GetMany(basket => basket.OrderStatus == OrderStatusEnum.CONFIRMED || basket.OrderStatus == OrderStatusEnum.PREPARING || basket.OrderStatus == OrderStatusEnum.DELIVERY || basket.OrderStatus == OrderStatusEnum.COMPLETED));

            if (partial)
            {
                return PartialView(orders);
            }
            else return View(orders);
        }

        public IActionResult OrdersConfirmed()
        {
            List<OrderViewModel> orders = new List<OrderViewModel>();

            orders = mapper.Map<List<OrderViewModel>>(orderService.GetMany(basket => basket.OrderStatus == OrderStatusEnum.CONFIRMED));

            return PartialView(orders);
        }

        public IActionResult OrdersPrepared()
        {
            List<OrderViewModel> orders = new List<OrderViewModel>();

            orders = mapper.Map<List<OrderViewModel>>(orderService.GetMany(basket => basket.OrderStatus == OrderStatusEnum.PREPARING));

            return PartialView(orders);
        }

        public IActionResult OrdersCompleted()
        {
            List<OrderViewModel> orders = new List<OrderViewModel>();

            orders = mapper.Map<List<OrderViewModel>>(orderService.GetMany(basket => basket.OrderStatus == OrderStatusEnum.DELIVERY));

            return PartialView(orders);
        }

        public IActionResult confirmedPayments()
        {
            List<OrderViewModel> orders = new List<OrderViewModel>();

            orders = mapper.Map<List<OrderViewModel>>(orderService.GetMany(basket => (basket.PaymentType == PaymentTypeEnum.CARD || basket.PaymentType == PaymentTypeEnum.CASH)));

            return PartialView(orders);
        }

        public IActionResult receivedOnline()
        {
            List<OrderViewModel> orders = new List<OrderViewModel>();

            orders = mapper.Map<List<OrderViewModel>>(orderService.GetMany(basket => basket.PaymentType == PaymentTypeEnum.MOBILE));

            return PartialView(orders);
        }

        public IActionResult completedOrders()
        {
            List<OrderViewModel> orders = new List<OrderViewModel>();

            orders = mapper.Map<List<OrderViewModel>>(orderService.GetMany(basket => basket.OrderStatus == OrderStatusEnum.COMPLETED));

            return PartialView(orders);
        }

        public async Task<IActionResult> UpdateForDelivery(int id)
        {
            try
            {
                var order = orderService.GetById(id);
                order.OrderStatus = OrderStatusEnum.PREPARING;
                orderService.Update(order);

                foreach (var pair in Sockets.wSockets)
                {
                    await Talk(pair.Value, "order prepared");
                }

                return Ok("delivery confirmed");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        public async Task<IActionResult> UpdateForCompleted(int id)
        {
            try
            {
                var order = orderService.GetById(id);
                order.OrderStatus = OrderStatusEnum.DELIVERY;
                orderService.Update(order);

                foreach (var pair in Sockets.wSockets)
                {
                    await Talk(pair.Value, "order completed");
                }

                var clientAPIRequest = WebRequest.Create("http://localhost:5556/api/order/updateOrderState" + "?sessionId=" + order.SessionId);

                var response = await clientAPIRequest.GetResponseAsync();


                return Ok("delivery confirmed");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        public async Task Talk(WebSocket wSocket, string message)
        {
            try
            {
                string text = string.Format(message);
                byte[] response = System.Text.Encoding.UTF8.GetBytes(text);
                await wSocket.SendAsync(new ArraySegment<byte>(response, 0, response.Length), WebSocketMessageType.Text, true, CancellationToken.None);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}