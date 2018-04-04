using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.ViewModels;

namespace Api.Services
{
    public interface ITeacherService
    {
         Task AddTeacherAsync(TeacherViewModel model);
         Task<IEnumerable<TeacherViewModel>> GetTeachersAsync();
         Task DeleteTeacherAsync(Guid Id);
         Task EditTeacherAsync(TeacherViewModel model);
         Task<TeacherViewModel> GetTecherByIdAsync(Guid Id);
    }
}