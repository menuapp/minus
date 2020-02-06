using AutoMapper;
using DAL.Interfaces;
using DAL.Repositories;
using Entity;
using Service.Domains;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class CommentService : ICommentService
    {
        private ICommentRepository commentRepository { get; set; }
        private IMapper mapper { get; set; }
        private IUnitOfWork unitOfWork;

        public CommentService(ICommentRepository commentRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.commentRepository = commentRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public bool Add(CommentDomain domain)
        {
            commentRepository.Add(mapper.Map<Comment>(domain));
            unitOfWork.Commit();
            return true;
        }

        public bool Delete(CommentDomain domain)
        {
            commentRepository.Delete(mapper.Map<Comment>(domain));
            unitOfWork.Commit();
            return true;
        }

        public IEnumerable<CommentDomain> GetAll()
        {
            return mapper.Map<IEnumerable<CommentDomain>>(commentRepository.GetAll());
        }

        public CommentDomain GetById(int id)
        {
            return mapper.Map<CommentDomain>(commentRepository.GetByIdEagerly(id));
        }

        public void Update(CommentDomain domain)
        {
            throw new NotImplementedException();
        }
    }
}
