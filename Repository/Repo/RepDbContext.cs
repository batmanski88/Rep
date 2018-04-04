
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
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectsV12;Initial Catalog=AppDataBase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        
        public async Task<int> SaveChangesAsync()
        {
            return  await base.SaveChangesAsync();
        }

       
    }
}