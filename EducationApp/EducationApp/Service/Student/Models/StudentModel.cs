using EducationApp.Data;

namespace EducationApp.Service.Student.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Password { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        public int StudentRegNumber { get; set; }

        public ICollection<StudentSubject>? StudentSubjects { get; set; }
    }
}
