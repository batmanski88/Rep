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
                teacher = new Teacher(Guid.NewGuid(), model.FirstName, model.LastName, model.Languages, model.City, model.Address, model.ZipCode);
                await _teacherRepo.AddTeacherAsync(teacher);
            }
        }

        public async Task DeleteTeacherAsync(Guid Id)
        {
            await _teacherRepo.DeleteTeacher(Id);
        }

        public async Task EditTeacherAsync(TeacherViewModel model)
        {
            var teacherId = (Guid)model.TeacherId;
            var teacher = await _teacherRepo.GetTeacherByIdAsync(model.TeacherId);
            if(teacher == null)
            {
                throw new Exception("Nauczyciel nie istnieje w bazie!");
            }
            else
            {
                teacher.SetFirsName(model.FirstName);
                teacher.SetLastName(model.LastName);
                teacher.SetLanguages(model.Languages);
                teacher.SetCity(model.City);
                teacher.SetAddress(model.Address);
                teacher.SetZipCode(model.ZipCode);
                await _teacherRepo.UpdateTeacherAsync(teacher);
            }
        }

        public async Task<IEnumerable<TeacherViewModel>> GetTeachersAsync()
        {
            var teachers = await  _teacherRepo.GetTeachersAsync();
            return _mapper.Map<IEnumerable<TeacherViewModel>>(teachers);
        }

        public async Task<TeacherViewModel> GetTecherByIdAsync(Guid Id)
        {
            var teacher = await _teacherRepo.GetTeacherByIdAsync(Id);
            
            return _mapper.Map<Teacher, TeacherViewModel>(teacher);
        }
    }
}