using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AdminUI.Extensions
{
    public class AppClaims
    {
        public List<Claim> Claims { get; set; }
        public AppClaims()
        {
            Claims = new List<Claim>()
        {
            new Claim("Create User",""),
            new Claim("Delete User",""),
            new Claim("Edit User",""),
            new Claim("Create Product",""),
            new Claim("Delete Product",""),
            new Claim("Edit Product",""),
            new Claim("Create Partner",""),
            new Claim("Delete Partner",""),
            new Claim("Edit Partner",""),
            new Claim("PartnerId","")
        };
        }

    }
}