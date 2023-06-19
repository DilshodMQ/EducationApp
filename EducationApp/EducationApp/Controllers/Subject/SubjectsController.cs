using AutoMapper;
using EducationApp.Controllers.Student.Models;
using EducationApp.Service.Student.Models;
using EducationApp.Service.Student;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EducationApp.Service.Subject;
using EducationApp.Controllers.Subject.Models;
using EducationApp.Data;
using EducationApp.Service.Subject.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace EducationApp.Controllers.Subject
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin, Teacher")]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        private readonly IMapper _mapper;
        public SubjectsController(ISubjectService subjectService, IMapper mapper)
        {
            _subjectService = subjectService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<SubjectResponse>> GetSubjects([FromQuery] int offset = 0, [FromQuery] int limit = 10)
        {
            var subjects = await _subjectService.GetAllSubjects(offset, limit);
            var response = _mapper.Map<IEnumerable<SubjectResponse>>(subjects);
            return response;

        }


        [HttpGet("GetTeachersSubjectWhich10StudentsHaveHigher80Ball")]
        public async Task<IEnumerable<SubjectResponse>> GetTeachersSubjectWhich10StudentsHaveHigher80Ball(int teacherId)
        {
            var subjects = await _subjectService.GetTeachersSubjectWhich10StudentsHaveHigher80Ball(teacherId);
            var response = _mapper.Map<IEnumerable<SubjectResponse>>(subjects);
            return response;

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectResponse>> GetSubject(int id)
        {
            var subject = await _subjectService.GetSubjectById(id);
            var response = _mapper.Map<SubjectResponse>(subject);
            return Ok(response);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubject(int id, [FromBody] UpdateSubjectRequest request)
        {
            var subject = _mapper.Map<UpdateSubjectModel>(request);
            await _subjectService.UpdateSubject(id, subject);
            return Ok();

        }


        [HttpPost]
        public async Task<SubjectResponse> PostSubject([FromBody] AddSubjectRequest request)
        {              
                var subjectModel = _mapper.Map<AddSubjectModel>(request);
                SubjectModel subject = await _subjectService.AddSubject(subjectModel);
                return _mapper.Map<SubjectResponse>(subject);           
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            await _subjectService.DeleteSubject(id);
            return Ok();
        }

        [HttpGet("GetSubjectWhichStudentsRatingIsBest")]
        public async Task<SubjectResponse> GetSubjectWhichStudentsRatingIsBest(int studentId)
        {
            var subject = await _subjectService.GetStudentsFavoriteSubject(studentId);
            var response = _mapper.Map<SubjectResponse>(subject);
            return response;
        }
        [HttpGet("GetSubjectWhichStudensAverageRatingHighest")]
        public async Task<SubjectResponse> GetSubjectWhichStudensAverageRatingHighest()
        {
            var subject = await _subjectService.GetSubjectWhichStudensAverageRatingHighest();
            var response = _mapper.Map<SubjectResponse>(subject);
            return response;
        }
        
    }
}
