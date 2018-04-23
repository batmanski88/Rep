using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Repository.Models;

namespace Repository
{
    public interface IUserRepo
    {
         Task<IEnumerable<User>> GetUsersAsync();
         Task<User> GetUserByIdAsync(Guid Id);
         Task AddUserAsync(User user);
         Task UpdateUserAsync(User user);
         Task RemoveUserAsync(Guid Id);
         Task<User> GetUserByEmailAsync(string email);
    }
}