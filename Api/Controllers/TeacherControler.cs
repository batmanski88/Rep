using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Services;
using Api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;

namespace Api.Controllers
{
    public class TeacherControler : Controller
    {
        private readonly ITeacherService _teacherService;
        public TeacherControler(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet]
        [Route("api/Teacher/GetTeachersAsync")]
        public async Task<IEnumerable<TeacherViewModel>> GetTeachersAsync()
        {
            return await _teacherService.GetTeachersAsync();
        }

        [HttpPost]
        [Route("api/Teacher/AddTeacherAsync")]
        public async Task<IActionResult> AddTeacherAsync([FromBody]TeacherViewModel model)
        {
            if(ModelState.IsValid)
            {
                await _teacherService.AddTeacherAsync(model);
            }

            return CreatedAtAction("GetTeachersAsync", new {id = model.TeacherId});
        }

        [HttpPut]
        [Route("api/Teacher/EditTeacherAsync")]
        public async Task<IActionResult> EditTeacherAsync([FromBody]TeacherViewModel model)
        {
            if(ModelState.IsValid)
            {
                await _teacherService.EditTeacherAsync(model);   
            }

            return NoContent();
        }

        [HttpDelete]
        [Route("api/Teacher/DeleteTeacherAsync/{Id}")]
        public async Task<IActionResult> DeleteTeacherAsync(Guid Id)
        {
            await _teacherService.DeleteTeacherAsync(Id);
            return NoContent();
        }

        [HttpGet]
        [Route("api/Teacher/details/{Id}")]
        public async Task<JsonResult> GetTeacherByIdAsync(Guid Id)
        {
            var teacher = await _teacherService.GetTecherByIdAsync(Id); 
            return Json(teacher);
        }
    }
}