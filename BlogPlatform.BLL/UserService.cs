﻿using AutoMapper;
using BlogPlatform.BLL.Mappings;
using BlogPlatform.DAL.Repositorys;
using BlogPlatform.DAL.DTOs;
using BlogPlatform.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogPlatform.BLL.Interfaces;
using BlogPlatform.DAL.Interfaces;

namespace BlogPlatform.BLL
{
    public class UserService : IUserService
    {
        private Mapper _mapper;
        private IUserRepository _userRepository;
        //private UserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.AddProfile(new UserMappingProfile());
                });
            _mapper = new Mapper(config);
        }


        public async Task<Guid> AddUser(UserModel user)
        {
            try
            {
                var userDTO = _mapper.Map<User>(user);

                var userId = await _userRepository.CreateUser(userDTO);

                return user.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                return user.Id;
            }
        }
        public async Task<List<UserModel>> GetAllUsers()
        {
            var userDTOs = await _userRepository.GetAllUsers();

            var users = _mapper.Map<List<UserModel>>(userDTOs);

            return users;
        }

        public async Task<UserModel> GetUserById(Guid id)
        {
            var userDTO = await _userRepository.GetUserById(id);
            return _mapper.Map<UserModel>(userDTO);
        }
        //public async Task UpdateUser(UserModel userModel)
        //{
        //    var userDTO = _mapper.Map<User>(userModel);
        //    await _userRepository.UpdateUser(userDTO, );
        //}

        public async Task RemoveUser(Guid id)
        {
            await _userRepository.RemoveUser(id);
        }

    }
}

