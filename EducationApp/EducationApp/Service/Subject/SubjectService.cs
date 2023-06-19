using AutoMapper;
using EducationApp.Data;
using EducationApp.Exeptions;
using EducationApp.Service.Subject.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EducationApp.Service.Subject
{
    public class SubjectService : ISubjectService
    {
        private readonly EducationAppContext _context;
        private readonly IMapper _mapper;
        public SubjectService(EducationAppContext context, IMapper mapper)
        {
           _context= context;
           _mapper= mapper;
        }
        public async Task<SubjectModel> AddSubject(AddSubjectModel model)
        {
            var subject=_mapper.Map<Data.Subject>(model);
            await _context.Subjects.AddAsync(subject);
            await _context.SaveChangesAsync();
            SubjectModel subjectModel=_mapper.Map<SubjectModel>(subject);
            return subjectModel;

        }

        public async Task DeleteSubject(int id)
        {
            var subject= await _context.Subjects.FirstOrDefaultAsync(x=>x.Id.Equals(id))
                ?? throw new ProcessException($"The subject (id: {id})  not found");
            if (subject != null)
            {
                _context.Subjects.Remove(subject);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<SubjectModel>> GetAllSubjects(int offset = 0, int limit = 10)
        {
            var subjects = _context
                .Subjects
                .AsQueryable();
            if(!subjects.Any())
                 throw new ProcessException($"Any subject not found");

            subjects = subjects
                .Skip(Math.Max(offset, 0))
                .Take(Math.Max(0, Math.Min(limit, 1000)));

            var data = (await subjects.ToListAsync()).Select(subject => _mapper.Map<SubjectModel>(subject));

            return data;
        }

        public async Task<SubjectModel> GetStudentsFavoriteSubject(int studentId)
        {
            List<StudentSubject> studentSubjects = _context.StudentSubjects
                                                   .Where(stSub => stSub.StudentId == studentId).ToList();
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id.Equals(studentId))
                ?? throw new ProcessException($"The student (id: {studentId}) was not found");
            if (!studentSubjects.Any())
                 throw new ProcessException($"This student has not added to any subject ");
            int favoriteSubjectId = 0;
            if (studentSubjects != null)
            {
                int favoriteSubjectIndex = 0;
                int? minRating = 0;
                for (int i = 0; i < studentSubjects.Count; i++)
                {
                    if (studentSubjects[i].Rating > minRating)
                    {
                        minRating = studentSubjects[i].Rating;
                        favoriteSubjectIndex = i;
                    }
                }
                favoriteSubjectId = studentSubjects[favoriteSubjectIndex].SubjectId;
            }

            var favoriteSubject = await _context.Subjects.FirstOrDefaultAsync(sb => sb.Id.Equals(favoriteSubjectId));
            return _mapper.Map<SubjectModel>(favoriteSubject);
        }

        public async Task<SubjectModel> GetSubjectById(int id)
        {
            var subject = await _context.Subjects.FirstOrDefaultAsync(x => x.Id.Equals(id))
                                    ?? throw new ProcessException($"The subject (id: {id})  not found");
            var data=_mapper.Map<SubjectModel>(subject);
            return data;
        }

        public async Task<SubjectModel> GetSubjectWhichStudensAverageRatingHighest()
        {
            var studentSubjects = _context.StudentSubjects
                .GroupBy(x => x.SubjectId).ToList();
            if(studentSubjects.Count == 0)
                  throw new ProcessException($"Any studentSubject   not found");
            double avgRating = 0;
            int subjectId = 0;
            for(int i=0; i<studentSubjects.Count; i++) 
            {
                if (avgRating < studentSubjects[i].Average(x => x.Rating))
                {
                    avgRating = (double)studentSubjects[i].Average(x => x.Rating);
                    subjectId = studentSubjects[i].Key;
                }
            }
            var subject=await _context.Subjects.FirstOrDefaultAsync(x=>x.Id.Equals(subjectId));
            return _mapper.Map<SubjectModel>(subject);
        }

        public async Task<IEnumerable<SubjectModel>> GetTeachersSubjectWhich10StudentsHaveHigher80Ball(int teacherId)
        {
            List<Data.Subject> teachersBestSubjects=new();
            var teacherSubjects = _context.Subjects
                .Include(sb => sb.StudentSubjects)
                .Where(sb => sb.TeacherId.Equals(teacherId)).ToList();

            for (int i = 0; i < teacherSubjects.Count; i++)
            {
                int subjectId = teacherSubjects[i].Id;
                int smartStudentsCount = 0;
                foreach (var studentSubject in teacherSubjects[i].StudentSubjects)
                {
                    if (studentSubject.Rating > 80)
                        smartStudentsCount++;
                }

                if (smartStudentsCount > 10)
                {
                    teachersBestSubjects.Add(teacherSubjects[i]);
                }
            }

            var data = teachersBestSubjects.Select(subject => _mapper.Map<SubjectModel>(subject));

            return data;

        }

        public async Task UpdateSubject(int id, UpdateSubjectModel model)
        {
            var subject = await _context.Subjects.FirstOrDefaultAsync(x => x.Id.Equals(id))
                 ?? throw new ProcessException($"The subject (id: {id})  not found");
            subject = _mapper.Map(model, subject);
                _context.Update(subject);
                await _context.SaveChangesAsync();          
        }
       
    }
}
