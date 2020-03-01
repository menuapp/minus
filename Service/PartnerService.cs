using AutoMapper;
using DAL.Interfaces;
using Entity;
using Service.Domains;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Service
{
    public class PartnerService : IPartnerService
    {
        private IPartnerRepository partnerRepository { get; set; }
        private IProductCategoryRepository productCategoryRepository { get; set; }
        private IProductRepository productRepository { get; set; }
        private IMapper mapper { get; set; }
        private IUnitOfWork unitOfWork;

        public PartnerService(IPartnerRepository partnerRepository, IProductCategoryRepository productCategoryRepository, IProductRepository productRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.productRepository = productRepository;
            this.productCategoryRepository = productCategoryRepository;
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
            try
            {
                var partner = partnerRepository.GetByIdEagerly((int)domain.Id);

                partnerRepository.Delete(partner);

                unitOfWork.Commit();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

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
            var updatedPartner = mapper.Map<Partner>(domain);
            var partner = partnerRepository.GetById((int)domain.Id);

            partner.AssociateAddress = updatedPartner.AssociateAddress;
            partner.AssociateName = updatedPartner.AssociateName;
            partner.AssociateUrl = updatedPartner.AssociateUrl;

            unitOfWork.Commit();
        }

        public IEnumerable<PartnerDomain> GetMany(Expression<Func<PartnerDomain, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PartnerDomain> GetAllEagerly()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PartnerDomain> GetManyEagerly(Expression<Func<PartnerDomain, bool>> where)
        {
            throw new NotImplementedException();
        }

        public PartnerDomain GetByIdEagerly(int id)
        {
            return mapper.Map<PartnerDomain>(partnerRepository.GetByIdEagerly(id));
        }
    }
}
