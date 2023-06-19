using AutoMapper;
using EducationApp.Data;
using EducationApp.Exeptions;
using EducationApp.Service.Teacher.Models;
using Microsoft.EntityFrameworkCore;

namespace EducationApp.Service.Teacher
{
    public class TeacherService : ITeacherService
    {
        private readonly EducationAppContext _context;
        private readonly IMapper _mapper;
        public TeacherService(EducationAppContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task AddSubjectToTeacher(AddSubjectToTeacher model)
        {
            var subject = await _context.Subjects.FirstOrDefaultAsync(x => x.Id.Equals(model.subjectId))
                ?? throw new ProcessException($"The subject (id: {model.subjectId}) was not found");

            var teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.Id.Equals(model.teacherId))
                ?? throw new ProcessException($"The teacher (id: {model.teacherId}) was not found");

            var teacherSubject = await _context.Subjects.Where(s=>s.TeacherId==model.teacherId).FirstOrDefaultAsync();
               
            if (teacherSubject != null)
                throw new ProcessException($"This subject has already added to this teacher");
            if (subject != null&&teacher!=null)
            {
                subject.TeacherId = teacher.Id;
                _context.Subjects.Update(subject);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<TeacherModel> AddTeacher(AddTeacherModel model)
        {
            var teacher = _mapper.Map<Data.Teacher>(model);
            teacher.RoleId = 2;
            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();
            TeacherModel tech = _mapper.Map<TeacherModel>(teacher);
            return tech;
        }

        public async Task DeleteTeacher(int teacherId)
        {
            var teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.Id.Equals(teacherId))
                                ?? throw new ProcessException($"The teacher (id: {teacherId}) was not found");

            if (teacher != null)
            {
                _context.Teachers.Remove(teacher);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TeacherModel>> GetAllTeachers(int offset = 0, int limit = 10)
        {
            var teachers = _context
                .Teachers
                .Include(t => t.Subjects)
                .AsQueryable(); 
              if(!teachers.Any())
                        throw new ProcessException($"Any teacher not found");


            teachers = teachers
                .Skip(Math.Max(offset, 0))
                .Take(Math.Max(0, Math.Min(limit, 1000)));

            var data = (await teachers.ToListAsync()).Select(teacher => _mapper.Map<TeacherModel>(teacher));

            return data;
        }

        public async Task<TeacherModel> GetTeacherById(int id)
        {
            var teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.Id.Equals(id))
                                ?? throw new ProcessException($"The teacher (id: {id}) was not found");

            return _mapper.Map<TeacherModel>(teacher);
        }

        public async Task<IEnumerable<TeacherModel>> GetTeachersWhoOlderThan55(int offset = 0, int limit = 10)
        {
            var teachers = _context
                .Teachers
                .Where(tch=>DateTime.Now.Year-tch.BirthDate.Year > 55)
                .AsQueryable();
            if (!teachers.Any())
                throw new ProcessException($"Any teacher who older than 55 years not found");

            teachers = teachers
                .Skip(Math.Max(offset, 0))
                .Take(Math.Max(0, Math.Min(limit, 1000)));

            var data = (await teachers.ToListAsync()).Select(teacher => _mapper.Map<TeacherModel>(teacher));

            return data;
        }

        public async Task<IEnumerable<TeacherModel>> GetTeachersWhoHisStudentsHaveGetHigherThan97()
        {
            var subjects = _context.Subjects.Include(s=>s.Teacher).Where(sub => sub.StudentSubjects.Any(sub => sub.Rating > 97));
            if (!subjects.Any())
                throw new ProcessException($"The subject which its studens rating higher than 97 not found");
            List<Data.Teacher> goodTeachers = new List<Data.Teacher>();
            foreach (var subject in subjects)
            {
                goodTeachers.Add(subject.Teacher);
            }
            var data =  goodTeachers.Select(teacher => _mapper.Map<TeacherModel>(teacher));
            return data;
        }

        public async Task StudentAssessment(StudentAssessmentModel model)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id.Equals(model.StudentId))
                                ?? throw new ProcessException($"The student (id: {model.StudentId}) was not found");

            var subject = await _context.Subjects.FirstOrDefaultAsync(x => x.Id.Equals(model.SubjectId))
                                ?? throw new ProcessException($"The subject (id: {model.SubjectId}) was not found");

            var studentSubject = await _context.StudentSubjects
                                .FirstOrDefaultAsync(stSub => stSub.StudentId == model.StudentId && stSub.SubjectId == model.SubjectId)
                                ?? throw new ProcessException($"This student has not added to this subject");

                studentSubject.Rating = model.Rating;
                _context.StudentSubjects.Update(studentSubject);
                await _context.SaveChangesAsync();
            
        }

        public async Task UpdateTeacher(int id, UpdateTeacherModel model)
        {
            var teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.Id.Equals(id))
            ?? throw new ProcessException($"The teacher (id: {id}) was not found");
            teacher.RoleId = 2;
            if (teacher != null)
            {
                teacher = _mapper.Map(model, teacher);
                _context.Teachers.Update(teacher);
                await _context.SaveChangesAsync();
            }
        }
    }
}
