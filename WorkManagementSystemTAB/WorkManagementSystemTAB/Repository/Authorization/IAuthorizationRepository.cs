using System;
using System.Threading.Tasks;
using WorkManagementSystemTAB.Models;

namespace WorkManagementSystemTAB.Repository.Authorization
{
    public interface IAuthorizationRepository : IRepository<User, Guid>
    {
        public Task<User> FindUserByEmailAsync(User user);
    }
}
