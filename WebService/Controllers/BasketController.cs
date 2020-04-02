using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Service;
using Service.Domains;
using Service.Interfaces;
using WebService.DTOs;
using static WebService.Startup;

namespace WebService.Controllers
{
    public class BasketInfoAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var authorization = context.HttpContext.Request.Headers["Authorization"];
            var jwtHandler = new JwtSecurityTokenHandler();
            authorization = Regex.Replace(authorization, "Bearer ", "");
            var token = (JwtSecurityToken)jwtHandler.ReadToken(authorization);

            ((BasketController)context.Controller).SessionId = authorization;
            ((BasketController)context.Controller).PartnerId = Int32.Parse(token.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Name).Value);
            ((BasketController)context.Controller).CounterId = Int32.Parse(token.Claims.FirstOrDefault(claim => claim.Type == "Table").Value);

            base.OnActionExecuting(context);
        }
    }


    [Route("api/[controller]/[action]")]
    [Authorize]
    [BasketInfo]
    public class BasketController : ControllerBase
    {
        public int PartnerId { get; set; }
        public int CounterId { get; set; }
        public string SessionId { get; set; }
        private IOrderService basketService { get; set; }
        private IMapper mapper { get; set; }
        public BasketController(IOrderService basketService, IMapper mapper) : base()
        {
            this.basketService = basketService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Get()
        {
            return Ok(mapper.Map<List<BasketDto>>(basketService.GetAll()));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(mapper.Map<BasketDto>(basketService.GetById(id)));
        }

        [HttpPost]
        public IActionResult Add([FromBody]BasketDto basket)
        {
            basket.PartnerId = PartnerId;
            basket.SessionId = SessionId;
            basket.CounterId = CounterId;
            basket.OrderDate = DateTime.Now.Date;

            basketService.Add(mapper.Map<OrderDomain>(basket));

            return RedirectToAction("Get", new { id = basket.Id });
        }

        public IActionResult GetBasket()
        {
            return Ok(mapper.Map<BasketDto>(basketService.GetBySession(SessionId)));
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody]OrderProductDto orderProduct)
        {
            var basket = basketService.GetBySession(SessionId);
            orderProduct.OrderId = (int)basket.Id;

            basketService.AddProduct(mapper.Map<OrderProductDomain>(orderProduct));
            return RedirectToAction("Get", new { id = basket.Id });
        }
        [HttpPost]
        public IActionResult RemoveProduct(OrderProductDto orderProduct)
        {
            var basket = basketService.GetBySession(SessionId);
            orderProduct.OrderId = (int)basket.Id;

            basketService.RemoveProduct(mapper.Map<OrderProductDomain>(orderProduct));
            return RedirectToAction("Get", new { id = basket.Id });
        }

        [HttpPost]
        public IActionResult UpdateProduct(OrderProductDto orderProduct)
        {
            var basket = basketService.GetBySession(SessionId);
            orderProduct.OrderId = (int)basket.Id;

            basketService.UpdateProduct(mapper.Map<OrderProductDomain>(orderProduct));
            return RedirectToAction("Get", new { id = basket.Id });
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

        [HttpPost]
        public async Task<IActionResult> Confirm([FromBody]BasketDto order)
        {
            try
            {
                //order.OrderProducts.ForEach(op =>
                //{
                //    if (op.IsDelivered == false)
                //    {
                //        op.IsDelivered = true;
                //    }
                //});

                order.OrderStatus = OrderStatusEnum.CONFIRMED;
                basketService.Update(mapper.Map<OrderDomain>(order));

                foreach (var pair in Sockets.wSockets)
                {
                    await Talk(pair.Value);
                }

                return Ok("confirmed");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Ok("error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> ChoosePayment([FromBody]BasketDto order)
        {
            try
            {
                basketService.Update(mapper.Map<OrderDomain>(order));

                foreach (var pair in Sockets.wSockets)
                {
                    await Talk(pair.Value);
                }

                return Ok("confirmed");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Ok("error");
            }
        }

        public async Task Talk(WebSocket wSocket)
        {
            try
            {
                string message = string.Format("new order confirmed");
                byte[] response = System.Text.Encoding.UTF8.GetBytes(message);
                await wSocket.SendAsync(new ArraySegment<byte>(response, 0, response.Length), WebSocketMessageType.Text, true, CancellationToken.None);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}