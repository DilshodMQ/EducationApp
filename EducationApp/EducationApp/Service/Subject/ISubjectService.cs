using EducationApp.Service.Subject.Models;

namespace EducationApp.Service.Subject
{
    public interface ISubjectService
    {
        Task<IEnumerable<SubjectModel>> GetAllSubjects(int offset = 0, int limit = 10);

        Task<SubjectModel> GetSubjectById(int id);
        Task<SubjectModel> GetStudentsFavoriteSubject(int studentId);
        Task<IEnumerable<SubjectModel>> GetTeachersSubjectWhich10StudentsHaveHigher80Ball(int teacherId);
        Task<SubjectModel> AddSubject(AddSubjectModel model);

        Task<SubjectModel> GetSubjectWhichStudensAverageRatingHighest();

        Task UpdateSubject(int id, UpdateSubjectModel model);

        Task DeleteSubject(int id);
    }
}
