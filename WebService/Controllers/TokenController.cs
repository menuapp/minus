using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get(int restaurantId, int tableId)
        {
            if (validateUser(restaurantId, tableId))
            {
                return Ok(new
                {
                    token = GenerateToken(restaurantId, tableId)
                });
            }
            else return Unauthorized();
        }

        public bool validateUser(int restaurantId, int tableId)
        {
            if (restaurantId == 1 && tableId == 1)
            {
                return true;
            }

            return false;
        }

        public string GenerateToken(int restaurantId, int tableId)
        {
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, restaurantId.ToString()),
                new Claim("Table", tableId.ToString()),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds().ToString())
            };

            var token = new JwtSecurityToken(
                new JwtHeader(new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("kivimenu, all rights reserved")), SecurityAlgorithms.HmacSha256))
                , new JwtPayload(claims));
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}