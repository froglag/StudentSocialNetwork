﻿using UserApplication.Models;

namespace UserApplication;
public interface IApplication
{
    Task<UserModel?> GetUser(int id);
    Task<IEnumerable<UserModel>> GetUsers();
    Task InsertUser(UserModel user);
    Task UpdateUser(UserModel user);
}