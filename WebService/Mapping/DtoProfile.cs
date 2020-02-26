using AutoMapper;
using Service.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService.DTOs;

namespace WebService.Mapping
{
    public class DtoProfile : Profile
    {
        public DtoProfile()
        {
            CreateMap<OrderProductDomain, OrderProductDto>();
            CreateMap<OrderProductDto, OrderProductDomain>();

            CreateMap<ProductCategoryDomain, ProductCategoryDto>();
            CreateMap<ProductCategoryDto, ProductCategoryDomain>();

            CreateMap<ProductCategoryDomain, ProductCategoryDto>();
            CreateMap<ProductCategoryDto, ProductCategoryDomain>();

            CreateMap<CommentDomain, CommentDto>();
            CreateMap<CommentDto, CommentDomain>();

            CreateMap<ContentDomain, ContentDto>();
            CreateMap<ContentDto, ContentDomain>();

            CreateMap<ProductDomain, ProductDto>();
            CreateMap<ProductDto, ProductDomain>();

            CreateMap<OrderDomain, BasketDto>();
            CreateMap<BasketDto, OrderDomain>();
        }
    }
}
