using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.ViewModels;
using AutoMapper;
using Repository;
using Repository.Models;

namespace Api.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepo _teacherRepo;
        private readonly IMapper _mapper;
        public TeacherService(ITeacherRepo teacherRepo, IMapper mapper)
        {
            _mapper = mapper;
            _teacherRepo = teacherRepo;
        }

        public async Task AddTeacherAsync(TeacherViewModel model)
        {
            var teacher = await _teacherRepo.GetTeacherByIdAsync(model.TeacherId);
            if(teacher != null)
            {
                throw new Exception("Nauczyciel już istnieje w bazie!");
            }
            else
            {
                teacher = new Teacher(Guid.NewGuid(), model.SchoolId, model.FirstName, model.LastName, model.Languages, model.City, model.Address, model.ZipCode);
            }
        }

        public async Task DeleteTeacherAsync(Guid Id)
        {
            await _teacherRepo.DeleteTeacher(Id);
        }

        public async Task EditTeacherAsync(TeacherViewModel model)
        {
            var teacher = await _teacherRepo.GetTeacherByIdAsync(model.TeacherId);
            if(teacher == null)
            {
                throw new Exception("Nauczyciel nie istnieje w bazie!");
            }
            else
            {
                Mapper.Map<Teacher, TeacherViewModel>(teacher);
                await _teacherRepo.UpdateTeacherAsync(teacher);
            }
        }

        public async Task<IEnumerable<TeacherViewModel>> GetTeachersAsync()
        {
            var teachers = await  _teacherRepo.GetTeachersAsync();
            return _mapper.Map<IEnumerable<TeacherViewModel>>(teachers);
        }
    }
}