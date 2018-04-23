using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository.Repo
{
    public class SchoolRepo : ISchoolRepo
    {

        private readonly IRepDbContext _dbContext;

        public SchoolRepo(IRepDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddSchoolAsync(School school)
        {
            await _dbContext.Schools.AddAsync(school);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteSchool(Guid Id)
        {
            var schools = await _dbContext.Schools.ToListAsync();
            _dbContext.Schools.Remove(schools.Where(x => x.SchoolId == Id).FirstOrDefault());
            await _dbContext.SaveChangesAsync();
        }

        public async Task<School> GetSchoolByIdAsync(Guid Id)
        {
            var schools = await _dbContext.Schools.ToListAsync();
            return schools.Where(x => x.SchoolId == Id).FirstOrDefault(); 
        }

        public async Task<IEnumerable<School>> GetSchoolsAsync()
        {
            return await _dbContext.Schools.ToListAsync();
        }

        public async Task UpdateSchoolAsync(School school)
        {
            _dbContext.Schools.Update(school);
            await _dbContext.SaveChangesAsync();
        }
    }
}