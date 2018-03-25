
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository.Repo
{
    public class RepDbContext : DbContext, IRepDbContext
    {
        public DbSet<Teacher> Teachers { get; set;}
        public DbSet<School> Schools {  get; set;}
        public DbSet<User> Users { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("");
        }

        public async Task<int> SaveChangesAsync()
        {
            return  await base.SaveChangesAsync();
        }
    }
}