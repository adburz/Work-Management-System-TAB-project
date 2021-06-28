﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkManagementSystemTAB.Models;

namespace WorkManagementSystemTAB.Repository.UserResitory
{
    public interface IUsersRepository : IRepository<User, Guid>
    {
        public Task<User> FindUserByEmailAsync(string email);
    }
}