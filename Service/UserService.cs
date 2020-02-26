using AutoMapper;
using DAL.Interfaces;
using DAL.Repositories;
using Entity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Service.Domains;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Service
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository { get; set; }
        private IMapper mapper { get; set; }
        private IUnitOfWork unitOfWork;

        public UserService(IUserRepository userRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<UserDomain> GetAll()
        {
            return mapper.Map<IEnumerable<UserDomain>>(userRepository.GetAll());
        }

        public bool Add(UserDomain userToCreate)
        {
            ApplicationUser newUser = mapper.Map<UserDomain, ApplicationUser>(userToCreate);

            try
            {
                userRepository.Add(newUser);
                unitOfWork.Commit();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return true;
        }

        public UserDomain GetById(string id)
        {
            return mapper.Map<ApplicationUser, UserDomain>(userRepository.GetById(id));
        }

        public bool Delete(UserDomain userDomain)
        {
            return userRepository.Delete(mapper.Map<UserDomain, ApplicationUser>(userDomain));
        }

        public void Update(UserDomain userDomain)
        {
            userRepository.Update(mapper.Map<UserDomain, ApplicationUser>(userDomain));
        }

        public IEnumerable<UserDomain> GetMany(Expression<Func<UserDomain, bool>> where)
        {
            throw new NotImplementedException();
        }
    }
}
