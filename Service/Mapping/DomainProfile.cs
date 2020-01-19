using AutoMapper;
using Entity;
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
            CreateMap<RoleDomain, Role>();
            CreateMap<Role, RoleDomain>();

            CreateMap<UserDomain, User>();
            CreateMap<User, UserDomain>();

            CreateMap<ProductDomain, Product>();
            CreateMap<Product, ProductDomain>();
        }
    }
}
