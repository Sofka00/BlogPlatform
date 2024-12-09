﻿using BlogPlatform.BLL.Models;
using System;

namespace BlogPlatform.BLL.Interfaces
{
    public interface IUserService
    {
        Task<Guid> AddUser(UserModel user);
        Task<List<UserModel>> GetAllUsers();
        Task<UserModel> GetUserById(Guid id);
        Task RemoveUser(Guid id);
        Task UpdateUser(UserModel userModel);
        Task<UserModel> ValidateUser(string login, string password);
        Task<UserModel> GetUserByName(string name);

    }
}   