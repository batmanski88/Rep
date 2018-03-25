using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository
{
    public interface IRepDbContext
    {
         DbSet<Teacher> Teachers {get; set;}
         DbSet<School> Schools {get; set;}
         DbSet<User> Users {get; set;}
         Task<int> SaveChangesAsync();
    }
}