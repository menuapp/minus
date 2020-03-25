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

            CreateMap<Order, OrderDomain>()
                .ForMember(dest => dest.OrderStatus, opt => opt.MapFrom(src => (OrderStatusEnum)src.OrderStatusId))
                .ForMember(dest => dest.OrderType, opt => opt.MapFrom(src => (OrderTypeEnum)src.OrderTypeId))
                .ForMember(dest => dest.PaymentType, opt => opt.MapFrom(src => (PaymentTypeEnum)src.PaymentTypeId));

            CreateMap<OrderDomain, Order>()
                .ForMember(dest => dest.OrderStatus, opt => opt.Ignore())
                .ForMember(dest => dest.OrderType, opt => opt.Ignore())
                .ForMember(dest => dest.PaymentType, opt => opt.Ignore())
                .ForMember(dest => dest.OrderStatusId, opt => opt.MapFrom(src => src.OrderStatus))
                .ForMember(dest => dest.OrderTypeId, opt => opt.MapFrom(src => src.OrderType))
                .ForMember(dest => dest.PaymentTypeId, opt => opt.MapFrom(src => src.PaymentType));

            CreateMap<OrderProductDomain, OrderProduct>();
            CreateMap<OrderProduct, OrderProductDomain>();

            CreateMap<TableDomain, Counter>();
            CreateMap<Counter, TableDomain>();
        }
    }
}
