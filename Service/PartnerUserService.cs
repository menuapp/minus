using AutoMapper;
using DAL.Interfaces;
using Entity;
using Service.Domains;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class PartnerUserService : IPartnerUserService
    {
        private IPartnerUserRepository partnerUserRepository { get; set; }
        private IMapper mapper { get; set; }
        private IUnitOfWork unitOfWork;

        public PartnerUserService(IPartnerUserRepository partnerUserRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.partnerUserRepository = partnerUserRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public bool Add(PartnerUserDomain domain)
        {
            partnerUserRepository.Add(mapper.Map<PartnerUser>(domain));
            unitOfWork.Commit();
            return true;
        }

        public bool Delete(PartnerUserDomain domain)
        {
            return partnerUserRepository.Delete(mapper.Map<PartnerUser>(domain));
        }

        public IEnumerable<PartnerUserDomain> GetAll()
        {
            return mapper.Map<IEnumerable<PartnerUserDomain>>(partnerUserRepository.GetAll());
        }

        public PartnerUserDomain GetById(int id)
        {
            throw new NotImplementedException();
        }

        public PartnerUserDomain GetById(string id)
        {
            return mapper.Map<PartnerUserDomain>(partnerUserRepository.GetByIdEagerly(id));
        }

        public void Update(PartnerUserDomain domain)
        {
            throw new NotImplementedException();
        }
    }
}
