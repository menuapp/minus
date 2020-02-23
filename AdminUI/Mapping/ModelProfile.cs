using AdminUI.Models;
using AutoMapper;
using Service.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminUI.Mapping
{
    public class ModelProfile : Profile
    {
        public ModelProfile()
        {
            CreateMap<RoleViewModel, IdentityRoleDomain>();
            CreateMap<IdentityRoleDomain, RoleViewModel>();

            CreateMap<ProductCategoryDomain, ProductCategoryViewModel>();
            CreateMap<ProductCategoryViewModel, ProductCategoryDomain>();//.ForMember(x => x.Id, opt => opt.Ignore());


            CreateMap<PartnerViewModel, PartnerDomain>();
            CreateMap<PartnerDomain, PartnerViewModel>();

            CreateMap<ProductViewModel, ProductDomain>();
            CreateMap<ProductDomain, ProductViewModel>();//.ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<CommentViewModel, CommentDomain>();
            CreateMap<CommentDomain, CommentViewModel>();

            CreateMap<ContentViewModel, ContentDomain>();
            CreateMap<ContentDomain, ContentViewModel>();

            CreateMap<UserViewModel, UserDomain>();
            CreateMap<UserDomain, UserViewModel>();

            CreateMap<OrderViewModel, OrderDomain>();
            CreateMap<OrderDomain, OrderViewModel>();

            CreateMap<TableViewModel, TableDomain>();
            CreateMap<TableDomain, TableViewModel>();
        }
    }
}
