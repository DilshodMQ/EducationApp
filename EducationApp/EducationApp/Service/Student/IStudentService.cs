using EducationApp.Service.Student.Models;

namespace EducationApp.Service.Student
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentModel>> GetAllStudents(int offset = 0, int limit = 10);
        Task<IEnumerable<StudentModel>> GetStudentsWhoYoungerThan20(int offset = 0, int limit = 10);

        Task<IEnumerable<StudentModel>> GetStudentsWhoBornBetween12August18September(int offset = 0, int limit = 10);
        Task<IEnumerable<StudentModel>> FindStudentWhoHisNameContainsText(string text);
        Task<StudentModel> GetStudentById(int id);
        Task<StudentModel> AddStudent(AddStudentModel model);

        Task UpdateStudent(int id, UpdateStudentModel model);

        Task DeleteStudent(int id);

        Task AddSubjectToStudent(AddSubjectToStudentModel model);


    }
}

