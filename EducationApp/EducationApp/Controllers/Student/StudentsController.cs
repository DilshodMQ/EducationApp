using AutoMapper;
using EducationApp.Controllers.Student.Models;
using EducationApp.Service.Student;
using EducationApp.Service.Student.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EducationApp.Controllers.Student
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        public StudentsController(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        [HttpGet]

        [Authorize(Roles = "Admin, Teacher, Student")]
        public async Task<ActionResult<IEnumerable<StudentResponse>>> GetStudents([FromQuery] int offset = 0, [FromQuery] int limit = 10)
        {
            var students = await _studentService.GetAllStudents(offset, limit);
            var response = _mapper.Map<IEnumerable<StudentResponse>>(students);
            return Ok(response);

        }

        [HttpGet("YoungerThan20")]
        [Authorize(Roles = "Admin, Teacher, Student")]
        public async Task<ActionResult<IEnumerable<StudentResponse>>> GetStudentsWhoYoungerThan20([FromQuery] int offset = 0, [FromQuery] int limit = 10)
        {
            var students = await _studentService.GetStudentsWhoYoungerThan20(offset, limit);
            var response = _mapper.Map<IEnumerable<StudentResponse>>(students);
            return Ok(response);
        }

        [HttpGet("FindStudentWhoHisNameContainsText")]
        public async Task<IEnumerable<StudentResponse>> FindStudentWhoHisNameContainsText([FromQuery] string text)
        {
            var students = await _studentService.FindStudentWhoHisNameContainsText(text);
            var response = _mapper.Map<IEnumerable<StudentResponse>>(students);
            return response;
        }

        [HttpGet("BornBetween12August18September")]
        public async Task<IEnumerable<StudentResponse>> GetStudentsWhoBornBetween12August18September([FromQuery] int offset = 0, [FromQuery] int limit = 10)
        {
            var students = await _studentService.GetStudentsWhoBornBetween12August18September(offset, limit);
            var response = _mapper.Map<IEnumerable<StudentResponse>>(students);
            return response;

        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, Teacher, Student")]
        public async Task<StudentResponse> GetStudent(int id)
        {
            var student = await _studentService.GetStudentById(id);
            var response = _mapper.Map<StudentResponse>(student);
            return response;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, [FromBody] UpdateStudentRequest request)
        {
            var student=_mapper.Map<UpdateStudentModel>(request);
            await _studentService.UpdateStudent(id, student);
            return Ok();    
           
        }
       
        [HttpPost]
        public async Task<StudentResponse> PostStudent([FromBody] AddStudentRequest request)
        {
                var studentModel = _mapper.Map<AddStudentModel>(request);
                StudentModel student = await _studentService.AddStudent(studentModel);
                return _mapper.Map<StudentResponse>(student);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            await _studentService.DeleteStudent(id);
            return Ok();
        }

        [HttpPost("AddSubjectToStudent")]
        public async Task<IActionResult> AddSubjectToStudent(AddSubjectToStudentModel model)
        {
            await _studentService.AddSubjectToStudent(model);
                return Ok();
        }
    }
}
