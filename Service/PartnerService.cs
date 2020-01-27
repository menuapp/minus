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
    public class PartnerService : IPartnerService
    {
        private IPartnerRepository partnerRepository { get; set; }
        private IMapper mapper { get; set; }
        private IUnitOfWork unitOfWork;

        public PartnerService(IPartnerRepository partnerRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.partnerRepository = partnerRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public bool Add(PartnerDomain domain)
        {
            partnerRepository.Add(mapper.Map<Partner>(domain));
            unitOfWork.Commit();
            return true;
        }

        public bool Delete(PartnerDomain domain)
        {
            return partnerRepository.Delete(mapper.Map<Partner>(domain));
        }

        public IEnumerable<PartnerDomain> GetAll()
        {
            var partners = mapper.Map<IEnumerable<PartnerDomain>>(partnerRepository.GetAll());
            return partners;
        }

        public PartnerDomain GetById(int id)
        {
            return mapper.Map<PartnerDomain>(partnerRepository.GetById(id));
        }

        public void Update(PartnerDomain domain)
        {
            throw new NotImplementedException();
        }
    }
}
