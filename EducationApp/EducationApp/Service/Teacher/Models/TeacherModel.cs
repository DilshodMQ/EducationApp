using EducationApp.Data;
using EducationApp.Service.Subject.Models;

namespace EducationApp.Service.Teacher.Models
{
    public class TeacherModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Password { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        public List<Data.Subject>? Subjects { get; set; }

    }
}
