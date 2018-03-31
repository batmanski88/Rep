using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Services;
using Api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class TeacherControler : Controller
    {
        private readonly ITeacherService _teacherService;
        public TeacherControler(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<TeacherViewModel>> GetTeachersAsync()
        {
            return await _teacherService.GetTeachersAsync();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddTeacherAsync([FromBody]TeacherViewModel model)
        {
            if(ModelState.IsValid)
            {
                await _teacherService.AddTeacherAsync(model);
            }

            return CreatedAtAction("GetTeachersAsync", new {id = model.TeacherId});
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> EditTeacherAsync([FromBody]TeacherViewModel model)
        {
            if(ModelState.IsValid)
            {
                await _teacherService.EditTeacherAsync(model);
            }

            return CreatedAtAction("GetTeachersAsync", new {id = model.TeacherId});
        }

        [HttpDelete("action")]
        public async Task<IActionResult> DeleteTeacherAsync(Guid Id)
        {
            await _teacherService.DeleteTeacherAsync(Id);
            return CreatedAtAction("GetTeachersAsync", new {id = Id});
        }
    }
}