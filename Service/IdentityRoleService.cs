using AutoMapper;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Service.Domains;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

        public bool Add(IdentityRoleDomain identityRoleDomain)
        {
            identityRoleRepository.Add(mapper.Map<IdentityRole>(identityRoleDomain));
            unitOfWork.Commit();
            return true;
        }

        public IEnumerable<IdentityRoleDomain> GetAll()
        {
            return mapper.Map<IEnumerable<IdentityRoleDomain>>(identityRoleRepository.GetAll());
        }

        public IdentityRoleDomain GetById(int id)
        {
            return mapper.Map<IdentityRoleDomain>(identityRoleRepository.GetByIdEagerly(id));
        }

        public bool Delete(IdentityRoleDomain domain)
        {
            return identityRoleRepository.Delete(mapper.Map<IdentityRole>(domain));
        }

        public void Update(IdentityRoleDomain domain)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IdentityRoleDomain> GetMany(Expression<Func<IdentityRoleDomain, bool>> where)
        {
            throw new NotImplementedException();
        }
    }
}
