using AutoMapper;
using Entity;
using Microsoft.AspNetCore.Identity;
using Service.Domains;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Service.Mapping
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<IdentityRoleDomain, IdentityRole>();
            CreateMap<IdentityRole, IdentityRoleDomain>();

            CreateMap<ProductCategory, ProductCategoryDomain>();
            CreateMap<ProductCategoryDomain, ProductCategory>();

            CreateMap<UserDomain, ApplicationUser>();
            CreateMap<ApplicationUser, UserDomain>();

            CreateMap<ProductDomain, Product>();
            CreateMap<Product, ProductDomain>();

            CreateMap<PartnerDomain, Partner>();
            CreateMap<Partner, PartnerDomain>();

            CreateMap<Content, ContentDomain>();
            CreateMap<ContentDomain, Content>();

            CreateMap<Comment, CommentDomain>();
            CreateMap<CommentDomain, Comment>();

            CreateMap<Order, OrderDomain>();
            CreateMap<OrderDomain, Order>();

            CreateMap<OrderProductDomain, OrderProduct>();
            CreateMap<OrderProduct, OrderProductDomain>();
        }
    }
}
