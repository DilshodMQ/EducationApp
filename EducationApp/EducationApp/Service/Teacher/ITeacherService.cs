using EducationApp.Service.Student.Models;
using EducationApp.Service.Teacher.Models;

namespace EducationApp.Service.Teacher
{
    public interface ITeacherService
    {
        Task<IEnumerable<TeacherModel>> GetAllTeachers(int offset = 0, int limit = 10);
        Task<IEnumerable<TeacherModel>> GetTeachersWhoOlderThan55(int offset = 0, int limit = 10);
        Task<IEnumerable<TeacherModel>> GetTeachersWhoHisStudentsHaveGetHigherThan97();
        Task<TeacherModel> GetTeacherById(int id);
        Task<TeacherModel> AddTeacher(AddTeacherModel model);

        Task UpdateTeacher(int id, UpdateTeacherModel model);

        Task DeleteTeacher(int id);
        Task AddSubjectToTeacher(AddSubjectToTeacher model);

        Task StudentAssessment(StudentAssessmentModel model);
    }
}
