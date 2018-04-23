using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository.Repo
{
    public class UserRepo : IUserRepo
    {
        private readonly IRepDbContext _dbContext;

        public UserRepo(IRepDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddUserAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid Id)
        {
            var users = await _dbContext.Users.ToListAsync();
            return users.Where(x => x.UserId == Id).FirstOrDefault();
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task RemoveUserAsync(Guid Id)
        {   
            var users = await  _dbContext.Users.ToListAsync();
            _dbContext.Users.Remove(users.Where(x => x.UserId == Id).FirstOrDefault()); 
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var users = await _dbContext.Users.ToListAsync();
            return users.Where(x => x.Email == email).FirstOrDefault();
        }
    }
}