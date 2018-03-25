using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Repository.Models;

namespace Repository
{
    public interface ITeacherRepo
    {
        Task<Teacher> GetTeacherByIdAsync(Guid Id);
        Task AddTeacherAsync(Teacher teacher);
        Task UpdateTeacherAsync(Teacher teacher);
        Task DeleteTeacher(Guid Id);
        Task<IEnumerable<Teacher>> GetTeachersAsync();
    }
}