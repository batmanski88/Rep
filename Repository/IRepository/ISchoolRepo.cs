using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Repository.Models;

namespace Repository
{   public interface ISchoolRepo
    {
        Task<School> GetSchoolByIdAsync(Guid Id);
        Task AddSchoolAsync(School school);
        Task UpdateSchoolAsync(School school);
        Task DeleteSchool(Guid Id);
        Task<IEnumerable<School>> GetSchoolsAsync();
    }
}