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
            CreateMap<RoleViewModel, RoleDomain>();
            CreateMap<RoleDomain, RoleViewModel>();

            CreateMap<UserViewModel, UserDomain>();
            CreateMap<UserDomain, UserViewModel>();
        }
    }
}
