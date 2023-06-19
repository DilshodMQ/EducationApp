using AutoMapper;
using EducationApp.Data;
using EducationApp.Exeptions;
using EducationApp.Service.Student.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace EducationApp.Service.Student
{
    public class StudentService : IStudentService
    {
        private readonly EducationAppContext _context;
        private readonly IMapper _mapper;
        public StudentService(EducationAppContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<StudentModel> AddStudent(AddStudentModel model)
        {
            var student = _mapper.Map<Data.Student>(model);
            student.RoleId = 3;
            await  _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            StudentModel st= _mapper.Map<StudentModel>(student);
            return st;
        }

        public async Task AddSubjectToStudent(AddSubjectToStudentModel model)
        {
            var student = await _context.Students.FirstOrDefaultAsync(st => st.Id.Equals(model.studentId))
                ?? throw new ProcessException($"The student (id: {model.studentId}) was not found");
            
            var subject = await _context.Subjects.FirstOrDefaultAsync(s => s.Id.Equals(model.subjectId))
            ?? throw new ProcessException($"The subject (id: {model.subjectId}) was not found");

            var studentSubject = await _context.StudentSubjects
                .FirstOrDefaultAsync(s => s.StudentId.Equals(model.studentId) && s.SubjectId.Equals(model.subjectId));
            if(studentSubject!=null)
            throw new ProcessException($"The student has already added to this subject");


            StudentSubject stSub = new StudentSubject();
            stSub.StudentId = model.studentId;
            stSub.SubjectId = model.subjectId;
            await _context.StudentSubjects.AddAsync(stSub);
            await _context.SaveChangesAsync();
        }

        public async  Task DeleteStudent(int studentId)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id.Equals(studentId))
                ?? throw new ProcessException($"The student (id: {studentId}) was not found");
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<StudentModel>> FindStudentWhoHisNameContainsText(string text)
        {
            var students = _context
                .Students
                .Where(st => st.FirstName.ToLower().Contains(text.ToLower()) || st.LastName.ToLower().Contains(text.ToLower()))
                .AsQueryable();
            if(!students.Any())
                 throw new ProcessException($"Any student who his FirstName or LastName contains {text} was not found");

            var data = (await students.ToListAsync()).Select(student => _mapper.Map<StudentModel>(student));

            return data;
        }

        public async Task<IEnumerable<StudentModel>> GetAllStudents(int offset = 0, int limit = 10)
        {
            var students = _context
                .Students
                .AsQueryable();
            if (!students.Any())
                throw new ProcessException($"Any student not found");

            students = students
                .Skip(Math.Max(offset, 0))
                .Take(Math.Max(0, Math.Min(limit, 1000)));

            var data = (await students.ToListAsync()).Select(student => _mapper.Map<StudentModel>(student));

            return data;
        }

        public async Task<StudentModel> GetStudentById(int id)
        {
            var student= await _context.Students.Include(st=>st.StudentSubjects).FirstOrDefaultAsync(x=>x.Id.Equals(id))
                ?? throw new ProcessException($"The student (id: {id}) was not found");
            return _mapper.Map<StudentModel>(student);
        }

        public async Task<IEnumerable<StudentModel>> GetStudentsWhoBornBetween12August18September(int offset = 0, int limit = 10)
        {
            var students = _context
                .Students
                .Where(st => (st.BirthDate.Day > 12 && st.BirthDate.Month.Equals(08)) || (st.BirthDate.Day < 18 && st.BirthDate.Month.Equals(09)))
                .AsQueryable();
            if (!students.Any())
                throw new ProcessException($"Any student  who born between 12 august and 18 september not found");

            students = students
                .Skip(Math.Max(offset, 0))
                .Take(Math.Max(0, Math.Min(limit, 1000)));

            var data = (await students.ToListAsync()).Select(student => _mapper.Map<StudentModel>(student));

            return data;
        }

        public async Task<IEnumerable<StudentModel>> GetStudentsWhoYoungerThan20(int offset = 0, int limit = 10)
        {
            var students = _context
                .Students
                .Where(st => DateTime.Now.Year - st.BirthDate.Year < 20)
                .AsQueryable();
            if (!students.Any())
                throw new ProcessException($"Any student  who younger than 20 not found");

            students = students
                .Skip(Math.Max(offset, 0))
                .Take(Math.Max(0, Math.Min(limit, 1000)));

            var data = (await students.ToListAsync()).Select(student => _mapper.Map<StudentModel>(student));

            return data;

        }

        public async Task UpdateStudent(int id, UpdateStudentModel model)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id.Equals(id))
                ?? throw new ProcessException($"The student (id: {id}) was not found");
            student.RoleId = 3;
            if (student != null)
            {
                student = _mapper.Map(model, student);
                _context.Students.Update(student);
                await _context.SaveChangesAsync();
            }
        }
    }
}
