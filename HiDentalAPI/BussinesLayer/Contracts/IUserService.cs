﻿using BussinesLayer.Repository.Contracts;
using DatabaseLayer.Models.Users;
using DataBaseLayer.Models.Users;
using DataBaseLayer.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Contracts
{
    public interface IUserService : IBaseRepository<User> , IHelperService<string>
    {
        Task<IEnumerable<User>> GetAllByUserAsync(string id);
        Task<User> GetUserById(string id);
        Task<bool> UpdateAsync(User model);
        Task<bool> UpdateDetailAsync(UserDetail model);
        Task<IEnumerable<User>> FilterAsync(FilterUserViewModel filters);


    }
}
