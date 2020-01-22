using AutoMapper;
using Entity;
using Microsoft.AspNetCore.Identity;
using Service.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Mapping
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<IdentityRoleDomain, IdentityRole>();
            CreateMap<IdentityRole, IdentityRoleDomain>();

            CreateMap<UserDomain, Customer>();
            CreateMap<Customer, UserDomain>();

            CreateMap<ProductDomain, Product>();
            CreateMap<Product, ProductDomain>();
        }
    }
}
