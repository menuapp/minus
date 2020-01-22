using AutoMapper;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Service.Domains;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class IdentityRoleService : IIdentityRoleService
    {
        private IIdentityRoleRepository identityRoleRepository { get; set; }
        private IMapper mapper { get; set; }
        private IUnitOfWork unitOfWork;

        public IdentityRoleService(IIdentityRoleRepository identityRoleRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.identityRoleRepository = identityRoleRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public bool AddRole(IdentityRoleDomain identityRoleDomain)
        {
            identityRoleRepository.Add(mapper.Map<IdentityRole>(identityRoleDomain));
            unitOfWork.Commit();
            return true;
        }

        public bool Delete(IdentityRoleDomain identityRoleDomain)
        {
            throw new NotImplementedException();
        }

        public IdentityRoleDomain GetRole(int id)
        {
            return mapper.Map<IdentityRoleDomain>(identityRoleRepository.GetById(id));
        }

        public IEnumerable<IdentityRoleDomain> ListRoles()
        {
            return mapper.Map<IEnumerable<IdentityRoleDomain>>(identityRoleRepository.GetAll());
        }

        public void Update(IdentityRoleDomain identityRoleDomain)
        {
            throw new NotImplementedException();
        }
    }
}
