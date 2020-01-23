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
            CreateMap<ProductCategoryViewModel, ProductCategoryDomain>();

            CreateMap<UserViewModel, UserDomain>();
            CreateMap<UserDomain, UserViewModel>();

            CreateMap<ProductViewModel, ProductDomain>();
            CreateMap<ProductDomain, ProductViewModel>();
        }
    }
}
