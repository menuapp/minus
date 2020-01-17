using AutoMapper;
using DAL.Interfaces;
using DAL.Repositories;
using Entity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Service.Domains;
using Service.Interfaces;
using System;
using System.Collections.Generic;
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

        public IEnumerable<UserDomain> ListUsers()
        {
            return mapper.Map<IEnumerable<User>, IEnumerable<UserDomain>>(userRepository.GetAll());
        }

        public bool CreateUser(UserDomain userToCreate)
        {
            User newUser = mapper.Map<UserDomain, User>(userToCreate);

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
    }
}
