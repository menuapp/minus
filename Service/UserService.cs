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
            return mapper.Map<IEnumerable<Customer>, IEnumerable<UserDomain>>(userRepository.GetAll());
        }

        public bool CreateUser(UserDomain userToCreate)
        {
            Customer newUser = mapper.Map<UserDomain, Customer>(userToCreate);

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

        public UserDomain GetUser(int id)
        {
            return mapper.Map<Customer, UserDomain>(userRepository.GetById(id));
        }

        public bool Delete(UserDomain userDomain)
        {
            return userRepository.Delete(mapper.Map<UserDomain, Customer>(userDomain));
        }

        public void Update(UserDomain userDomain)
        {
            userRepository.Update(mapper.Map<UserDomain, Customer>(userDomain));
        }
    }
}
