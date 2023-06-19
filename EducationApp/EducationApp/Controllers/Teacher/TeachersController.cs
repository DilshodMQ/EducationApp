using AutoMapper;
using EducationApp.Controllers.Teacher.Models;
using EducationApp.Service.Teacher;
using EducationApp.Service.Teacher.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EducationApp.Controllers.Teacher
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        private readonly IMapper _mapper;
        public TeachersController(ITeacherService teacherService, IMapper mapper)
        {
            _teacherService = teacherService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Teacher")]
        public async Task<IEnumerable<TeacherResponse>> GetTeachers([FromQuery] int offset = 0, [FromQuery] int limit = 10)
        {
            var teachers = await _teacherService.GetAllTeachers(offset, limit);
            var response = _mapper.Map<IEnumerable<TeacherResponse>>(teachers);
            return response;

        }


        [HttpGet("WhoOlderThan55")]
        [Authorize(Roles = "Admin")]
        public async Task<IEnumerable<TeacherResponse>> GetTeachersWhoOlderThan55([FromQuery] int offset = 0, [FromQuery] int limit = 10)
        {
            var teachers = await _teacherService.GetTeachersWhoOlderThan55(offset, limit);
            var response = _mapper.Map<IEnumerable<TeacherResponse>>(teachers);
            return response;

        }
        
        [HttpGet("HisStudentsHaveGetHigherThan97")]
        [Authorize(Roles = "Admin, Teacher")]
        public async Task<IEnumerable<TeacherResponse>> GetTeachersWhoHisStudentsHaveGetHigherThan97()
        {
             var teachers = await _teacherService.GetTeachersWhoHisStudentsHaveGetHigherThan97();
            var response = _mapper.Map<IEnumerable<TeacherResponse>>(teachers);
            return response;

        
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, Teacher")]
        public async Task<TeacherResponse> GetTeacher(int id)
        {
            var teacher = await _teacherService.GetTeacherById(id);
            var response = _mapper.Map<TeacherResponse>(teacher);
            return response;
        }


        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutTeacher(int id, [FromBody] UpdateTeacherRequest request)
        {
            var teacher = _mapper.Map<UpdateTeacherModel>(request);
            await _teacherService.UpdateTeacher(id, teacher);
            return Ok();

        }


        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<TeacherResponse> PostTeacher([FromBody] AddTeacherRequest request)
        {            
                var teacherModel = _mapper.Map<AddTeacherModel>(request);
                TeacherModel teacher = await _teacherService.AddTeacher(teacherModel);
                return _mapper.Map<TeacherResponse>(teacher);            
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            await  _teacherService.DeleteTeacher(id);
            return Ok();
        }

        [HttpPost("AddSubjectToTeacher")]
        [Authorize(Roles = "Admin, Teacher")]
        public async Task<IActionResult> AddSubjectToTeacher(AddSubjectToTeacher model)
        {
            await _teacherService.AddSubjectToTeacher(model);
            return Ok();
        }

        [HttpPost("StudentAssessment")]
        [Authorize(Roles = "Teacher, Admin")]
        public async Task<IActionResult> StudentAssesment(StudentAssessmentModel model)
        {
            await _teacherService.StudentAssessment(model);
            return Ok();
        }
    }
}
