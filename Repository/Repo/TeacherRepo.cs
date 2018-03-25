using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Repository.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repo
{
    public class TeacherRepo : ITeacherRepo
    {
        private readonly IRepDbContext _repDbContext;

        public TeacherRepo(IRepDbContext repDbContext)
        {
            _repDbContext = repDbContext;
        }
        public async Task AddTeacherAsync(Teacher teacher)
        {
           await  _repDbContext.Teachers.AddAsync(teacher);
           await _repDbContext.SaveChangesAsync();
        }

        public async Task DeleteTeacher(Guid Id)
        {
            var teacher = _repDbContext.Teachers.FirstOrDefault(x => x.TeacherId == Id);
            _repDbContext.Teachers.Remove(teacher);      
            await _repDbContext.SaveChangesAsync();
        }

        public async Task<Teacher> GetTeacherByIdAsync(Guid Id)
        {
            var teachers = await _repDbContext.Teachers.ToListAsync();
            var teacher = teachers.FirstOrDefault(x => x.TeacherId == Id);
            return  teacher;
        }

        public async Task<IEnumerable<Teacher>> GetTeachersAsync()
        {
            return await _repDbContext.Teachers.ToListAsync();
        }

        public async Task UpdateTeacherAsync(Teacher teacher)
        {
            _repDbContext.Teachers.Update(teacher);
            await _repDbContext.SaveChangesAsync();
        }
    }
}