using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static WebService.Startup;

namespace WebService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public async Task<IActionResult> UpdateOrderState(string sessionId)
        {
            WebSocket webSocket = Sockets.clientSockets.FirstOrDefault(pair => pair.Key == sessionId).Value;
            
            if (webSocket == null)
            {
                return Ok("client could not be found");
            }

            await Talk(webSocket);

            return Ok("client notified");
        }


        public async Task Talk(WebSocket wSocket)
        {
            try
            {
                string message = string.Format("order delivered");
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